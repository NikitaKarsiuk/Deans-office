using DeansOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DeansOffice.Windows
{
    /// <summary>
    /// Interaction logic for Subject.xaml
    /// </summary>
    public partial class Subject : Window
    {
        private int Id { get; set; }
        private int GroupId { get; set; }
        public Subject(int Id = -1)
        {
            InitializeComponent();
            this.Id = Id;

            if (Id != -1)
            {
                using (DataContext db = new DataContext())
                {
                    var Subjects = db.Subject.Find(Id);
                    NameTextBox.Text = Subjects.Name.ToString();
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DataContext db = new DataContext())
                {
                    var subjectList = db.Subject.ToList();

                    if (NameTextBox.Text == "")
                        throw new ArgumentException("Ошибка. Поле 'Предмет' не должно быть пустым");
                    if (!Regex.IsMatch(NameTextBox.Text, @"[А-я]"))
                        throw new ArgumentException("Ошибка. Поле 'Предмет' должна содержать только кириллицу");

                    if (Id == -1)
                    {
                        db.Subject.Add(new Models.Subject()
                        {
                            Name = NameTextBox.Text                            
                        });
                    }
                    else
                    {
                        var subjectItem = db.Subject.Find(Id);
                        subjectItem.Name = NameTextBox.Text;
                    }

                    db.SaveChanges();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

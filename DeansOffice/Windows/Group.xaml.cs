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
using DeansOffice.Models;

namespace DeansOffice.Windows
{
    /// <summary>
    /// Interaction logic for Group.xaml
    /// </summary>
    public partial class Group : Window
    {
        private int Id { get; set; }
        public Group(int Id = -1)
        {
            this.Id = Id;
            InitializeComponent();

            using (DataContext db = new DataContext())
            {
                FacultyComboBox.ItemsSource = db.Faculty.ToList();

                if(Id != -1)
                {
                    var items = db.Group.Find(Id);
                    NameTextBox.Text = items.Name;
                    FacultyComboBox.SelectedItem = items.Faculty;
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DataContext db = new DataContext())
                {
                    if (NameTextBox.Text == "" || !Regex.IsMatch(NameTextBox.Text, @"[A-Z]-[0-9]{3}"))
                        throw new ArgumentException("Ошибка. Поле 'Группа' должно содержать информацию");
                    if (Id == -1)
                    {
                        if (db.Group.Where(x => x.Name == NameTextBox.Text).Count() > 0)
                            throw new ArgumentException("Ошибка. Поле 'Группа' уже сущесвует");
                    }
                    else
                    {
                        if (db.Group.Where(x => x.Name == NameTextBox.Text).Count() > 1)
                            throw new ArgumentException("Ошибка. Поле 'Группа' уже сущесвует");
                    }
                    if (FacultyComboBox.Text == "")
                        throw new ArgumentException("Ошибка. Выберите кафедру");

                    if(Id == -1)
                    {
                        db.Group.Add(new Models.Group()
                        {
                            Name = NameTextBox.Text,
                            FacultyId = (FacultyComboBox.SelectedItem as Models.Faculty).Id
                        });
                    }
                    else
                    {
                        var item = db.Group.Find(Id);
                        item.Name = NameTextBox.Text;
                        item.FacultyId = (FacultyComboBox.SelectedItem as Models.Faculty).Id;
                    }
                    db.SaveChanges();
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

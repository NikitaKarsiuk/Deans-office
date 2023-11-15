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
    /// Interaction logic for Student.xaml
    /// </summary>
    public partial class Student : Window
    {
        private int Id { get; set; }
        public Student(int Id = -1)
        {
            this.Id = Id;
            InitializeComponent();

            using (DataContext db = new DataContext())
            {
                GroupComboBox.ItemsSource = db.Group.ToList();

                if (Id != -1)
                {
                    var item = db.Student.Find(Id);

                    NameTextBox.Text = item.Name.ToString();
                    SurnameTextBox.Text = item.Surname.ToString();
                    PatronymicTextBox.Text = item.Patronymic.ToString();
                    GroupComboBox.SelectedItem = item.Group;
                }

            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DataContext db = new DataContext())
                {
                    if (NameTextBox.Text == "" || !Regex.IsMatch(NameTextBox.Text, @"[А-яA-z]"))
                        throw new ArgumentException("Ошибка. Вы не заполнили поле имя");
                    if (SurnameTextBox.Text == "" || !Regex.IsMatch(SurnameTextBox.Text, @"[А-яA-z]"))
                        throw new ArgumentException("Ошибка. Вы не заполнили поле фамилия");
                    if (PatronymicTextBox.Text == "" || !Regex.IsMatch(PatronymicTextBox.Text, @"[А-яA-z]"))
                        throw new ArgumentException("Ошибка. Вы не заполнили поле отчество");
                    if (GroupComboBox.Text == "")
                        throw new ArgumentException("Ошибка. Вы не выбрали группу");
                   
                    if (Id == -1)
                    {
                        db.Student.Add(new Models.Student()
                        {
                            Name = NameTextBox.Text,
                            Surname = SurnameTextBox.Text,
                            Patronymic = PatronymicTextBox.Text,
                            GroupId = (GroupComboBox.SelectedItem as Models.Group).Id
                        });
                        db.SaveChanges();
                        this.Close();
                    }
                    else
                    {
                        var item = db.Student.Find(Id);
                        item.Name = NameTextBox.Text;
                        item.Surname = SurnameTextBox.Text;
                        item.Patronymic = PatronymicTextBox.Text;
                        item.GroupId = (GroupComboBox.SelectedItem as Models.Group).Id;
                        db.SaveChanges();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

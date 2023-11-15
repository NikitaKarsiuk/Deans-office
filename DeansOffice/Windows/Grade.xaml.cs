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
    /// Interaction logic for Grade.xaml
    /// </summary>
    public partial class Grade : Window
    {
        private int StudentId { get; set; }
        private int Id { get; set; }
        public Grade(int StudentId, int Id = -1)
        {
            this.StudentId = StudentId;
            this.Id = Id;
            
            InitializeComponent();

            using (DataContext db = new DataContext())
            {
                var student = db.Student.Find(StudentId);
                var subjectGroupList = db.SubjectGroupList.Where(x => x.GroupId == student.GroupId).ToList();
                List<Models.Subject> subject = new List<Models.Subject>();
                foreach (var item in subjectGroupList)
                {
                    subject.Add(db.Subject.Find(item.SubjectId));
                }

                SubjectComboBox.ItemsSource = subject;

                if (Id != -1)
                {
                    var item = db.StudentGrades.Find(Id);
                    SubjectComboBox.SelectedItem = item.Subject;
                    GradeTextBox.Text = item.Grade.ToString();
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DataContext db = new DataContext())
                {
                    if (SubjectComboBox.Text == "")
                        throw new ArgumentException("Ошибка. Выберите предмет");
                    if (GradeTextBox.Text == "" || !Regex.IsMatch(GradeTextBox.Text, @"(10|[1-9])"))
                        throw new ArgumentException("Ошибка. Поле 'Оценка' должно содержать только цифру");
                    if (int.Parse(GradeTextBox.Text) < 1 || int.Parse(GradeTextBox.Text) > 10)
                        throw new ArgumentException("Ошибка. Поле 'Оценка' должно быть от 1 до 10");

                    if (Id == -1)
                    {
                        db.StudentGrades.Add(new Models.StudentGrades()
                        {
                            StudentId = StudentId,
                            SubjectId = (SubjectComboBox.SelectedItem as Models.Subject).Id,
                            Grade = int.Parse(GradeTextBox.Text)
                        });
                    }
                    else
                    {
                        var item = db.StudentGrades.Find(Id);
                        item.StudentId = StudentId;
                        item.SubjectId = (SubjectComboBox.SelectedItem as Models.Subject).Id;
                        item.Grade = int.Parse(GradeTextBox.Text);
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

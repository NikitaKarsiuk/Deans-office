using DeansOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for SubjectAvarageGrades.xaml
    /// </summary>
    public partial class SubjectAvarageGrades : Window
    {
        public SubjectAvarageGrades()
        {
            InitializeComponent();
            List<Models.SubjectAvarageGrade> subjectAvarageGradesList = new List<Models.SubjectAvarageGrade>();
            using (DataContext db = new DataContext()) 
            {
                foreach (var subject in db.Subject.ToList())
                {
                    double sumOfGrade = 0;
                    int count = 0;
                    foreach(var grade in db.StudentGrades.Where(x => x.SubjectId == subject.Id))
                    {
                        sumOfGrade += grade.Grade;
                        count++;
                    }
                    if (sumOfGrade > 0)
                    {
                        subjectAvarageGradesList.Add(new SubjectAvarageGrade()
                        {
                            Id = subject.Id,
                            Name = subject.Name,
                            AvarageGrade = sumOfGrade / count
                        });
                    }
                    else
                    {
                        subjectAvarageGradesList.Add(new SubjectAvarageGrade()
                        {
                            Id = subject.Id,
                            Name = subject.Name,
                            AvarageGrade = 0
                        });
                    }
                }
                subjectAvarageGradeDataGrid.ItemsSource = subjectAvarageGradesList;
                subjectAvarageGradeDataGrid.Items.Refresh();
            }
        }
        private void GroupAvarageHighGrade_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DataContext db = new DataContext())
                {
                    var items = subjectAvarageGradeDataGrid.ItemsSource as List<Models.SubjectAvarageGrade>;
                    var item = subjectAvarageGradeDataGrid.SelectedItem as Models.SubjectAvarageGrade;
                    double highAvgGrade = 0;
                    string nameOfGroup = "";
                    foreach(var group in db.Group.ToList())
                    {
                        double avgGrade = 0;
                        int count = 0;
                        foreach(var student in db.Student.Where(x => x.GroupId == group.Id).ToList())
                        {
                            foreach(var studentGrades in db.StudentGrades.Where(x => x.SubjectId == item.Id).ToList())
                            {
                                avgGrade += studentGrades.Grade;
                                count++;
                            }
                        }
                        if(avgGrade != 0 && (avgGrade / count) > highAvgGrade)
                        {
                            highAvgGrade = avgGrade / count;
                            nameOfGroup = group.Name;
                        }
                        count = 0;
                    }

                    if (highAvgGrade != 0)
                    {
                        MessageBox.Show($"Группа с наивысшим средним баллом: {nameOfGroup}, {highAvgGrade}");
                    }
                    else
                    {
                        MessageBox.Show($"По данному предмету отсутствуют оценки");
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

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
    /// Interaction logic for StudentAvarageGrades.xaml
    /// </summary>
    public partial class StudentAvarageGrades : Window
    {
        private int Id { get; set; }
        public StudentAvarageGrades(int Id)
        {
            InitializeComponent();
            using (DataContext db = new DataContext())
            {
                var groupList = db.Group.Where(x => x.FacultyId == Id).ToList();
                List<Models.GroupAvarageGrade> _groupList = new List<Models.GroupAvarageGrade>();
                foreach (var group in groupList)
                {
                    double avgAllSubjets = 0;
                    int count = 0;
                    int amountOfSubjects = 0;
                    int amountOfStudents = 0;
                    foreach (var student in db.Student.Where(x => x.GroupId == group.Id).ToList())
                    {
                        foreach (var subject in  db.SubjectGroupList.Where(x => x.GroupId == group.Id).ToList())
                        {
                            double avgSubject = 0;
                            foreach(var avgGrade in db.StudentGrades.Where(x => x.StudentId == student.Id && x.SubjectId == subject.SubjectId))
                            {
                                avgSubject += avgGrade.Grade;
                                count++;
                            }
                            amountOfSubjects++;
                            if (count != 0)
                            {
                                avgAllSubjets += avgSubject / count;
                            }
                            else
                            {
                                avgAllSubjets += 0;
                            }
                        }
                        amountOfStudents++;
                    }
                    if (avgAllSubjets > 0)
                    {
                        _groupList.Add(new GroupAvarageGrade()
                        {
                            Id = group.Id,
                            Name = group.Name,
                            AverageGrade = avgAllSubjets / amountOfStudents
                        });
                    }
                    else
                    {
                        _groupList.Add(new GroupAvarageGrade()
                        {
                            Id = group.Id,
                            Name = group.Name,
                            AverageGrade = 0
                        });
                    }
                    avgAllSubjets = 0;
                }


                studentListDataGrid.ItemsSource = _groupList;
                studentListDataGrid.Items.Refresh();
            }
        }
    }
}

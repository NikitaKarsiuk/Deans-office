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
using DeansOffice.Models;

namespace DeansOffice.Windows
{
    /// <summary>
    /// Interaction logic for StudentExplusionList.xaml
    /// </summary>
    public partial class StudentExplusionList : Window
    {
        private int Id;
        public StudentExplusionList(int Id)
        {
            this.Id = Id;
            InitializeComponent();
            using(DataContext db = new DataContext())
            {
                List<Models.Student> studentList = new List<Models.Student>();
                foreach(var group in db.Group.Where(x => x.FacultyId == Id).ToList())
                {
                    
                    if(db.SubjectGroupList.Where(x => x.GroupId == group.Id).Count() > 2)
                    {
                        foreach (var student in db.Student.Where(x => x.GroupId == group.Id))
                        {
                            int negativeSubject = 0;
                            double avgGrade = 0;
                            int count = 0;
                            foreach(var subject in db.SubjectGroupList.Where(x => x.GroupId == group.Id))
                            {
                                foreach(var studentGrade in db.StudentGrades.Where(x => x.SubjectId == subject.SubjectId && x.StudentId == student.Id).ToList())
                                {
                                    avgGrade += studentGrade.Grade;
                                    count++;
                                }
                                if (avgGrade == 0 || (avgGrade / count) < 4) 
                                {
                                    negativeSubject++;
                                }
                            }
                            if(negativeSubject > 2)
                            {
                                studentList.Add(student);
                            }
                        }
                    }
                }

                studentExplusionListDataGrid.ItemsSource = studentList;
                studentExplusionListDataGrid.Items.Refresh();
            }
        }
    }
}

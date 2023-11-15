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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DeansOffice.Models;

namespace DeansOffice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DirectoryFillTabItem("FacultyTabItem");
        }
        private void FillTabItem_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var nameTabItem = (sender as TabItem).Name.ToString(); ;
            DirectoryFillTabItem(nameTabItem);
        }
        private void DirectoryFillTabItem(string tabItemName)
        {
            using (DataContext db = new DataContext())
            {
                if(tabItemName == "FacultyTabItem")
                {
                    var items = db.Faculty.ToList();
                    facultyDataGrid.ItemsSource = items;
                    facultyDataGrid.Items.Refresh();
                }
                if (tabItemName == "GroupTabItem")
                {
                    var items = db.Group.ToList();
                    groupDataGrid.ItemsSource = items;
                    groupDataGrid.Items.Refresh();
                }
                if (tabItemName == "DepartmentTabItem")
                {
                    var items = db.Faculty.ToList();
                    facultyDataGrid.ItemsSource = items;
                    facultyDataGrid.Items.Refresh();
                }
                if (tabItemName == "SubjectTabItem")
                {
                    var items = db.Subject.ToList();
                    subjectDataGrid.ItemsSource = items;
                    subjectDataGrid.Items.Refresh();
                }
                if (tabItemName == "StudentTabItem")
                {
                    var items = db.Student.ToList();
                    studentDataGrid.ItemsSource = items;
                    studentDataGrid.Items.Refresh();
                }
            }
        }

        private void FacultyAddButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.Faculty faculty = new Windows.Faculty();
            faculty.Closed += new EventHandler((_s, _e) =>
            {
                DirectoryFillTabItem("FacultyTabItem");
            });
            faculty.Show();
        }

        private void FacultyChangeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (facultyDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = facultyDataGrid.ItemsSource as List<Models.Faculty>;
                var item = facultyDataGrid.SelectedItem as Models.Faculty;

                Windows.Faculty faculty = new Windows.Faculty(item.Id);
                faculty.Closed += new EventHandler((_s, _e) =>
                {
                    DirectoryFillTabItem("FacultyTabItem");
                });
                faculty.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FacultyDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (facultyDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = facultyDataGrid.ItemsSource as List<Models.Faculty>;
                var item = facultyDataGrid.SelectedItem as Models.Faculty;

                using (DataContext db = new DataContext())
                {
                    if (db.Group.Where(x => x.FacultyId == item.Id).Count() > 0)
                        throw new ArgumentException("Выбранный вами факультет, удалить нельзя");

                    var faculty = db.Faculty.Find(item.Id);

                    db.Faculty.Remove(faculty);
                    db.SaveChanges();
                }

                items.Remove(item);
                DirectoryFillTabItem("FacultyTabItem");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GroupAddButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.Group group = new Windows.Group();
            group.Closed += new EventHandler((_s, _e) =>
            {
                DirectoryFillTabItem("GroupTabItem");
            });
            group.Show();
        }

        private void GroupChangeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (groupDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = groupDataGrid.ItemsSource as List<Models.Group>;
                var item = groupDataGrid.SelectedItem as Models.Group;

                Windows.Group group = new Windows.Group(item.Id);
                group.Closed += new EventHandler((_s, _e) =>
                {
                    DirectoryFillTabItem("GroupTabItem");
                });
                group.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GroupDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (groupDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = groupDataGrid.ItemsSource as List<Models.Group>;
                var item = groupDataGrid.SelectedItem as Models.Group;

                using (DataContext db = new DataContext())
                {
                    if (db.Student.Where(x => x.GroupId == item.Id).Count() > 0)
                        throw new ArgumentException("Выбранную вами группу, удалить нельзя");

                    var group = db.Group.Find(item.Id);

                    db.Group.Remove(group);
                    db.SaveChanges();
                }

                items.Remove(item);
                DirectoryFillTabItem("GroupTabItem");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenSubjectWindow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (groupDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = groupDataGrid.ItemsSource as List<Models.Group>;
                var item = groupDataGrid.SelectedItem as Models.Group;

                Windows.SubjectList subjectList = new Windows.SubjectList(item.Id);
                subjectList.Closed += new EventHandler((_s, _e) =>
                {
                    DirectoryFillTabItem("GroupTabItem");
                });
                subjectList.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenStudentWindow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (groupDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = groupDataGrid.ItemsSource as List<Models.Group>;
                var item = groupDataGrid.SelectedItem as Models.Group;

                Windows.StudentList subjectList = new Windows.StudentList(item.Id);
                subjectList.Closed += new EventHandler((_s, _e) =>
                {
                    DirectoryFillTabItem("GroupTabItem");
                });
                subjectList.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenStudentAvarageGradesWindow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (facultyDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = facultyDataGrid.ItemsSource as List<Models.Faculty>;
                var item = facultyDataGrid.SelectedItem as Models.Faculty;

                Windows.StudentAvarageGrades studentAvgList = new Windows.StudentAvarageGrades(item.Id);
                studentAvgList.Closed += new EventHandler((_s, _e) =>
                {
                    DirectoryFillTabItem("FacultyTabItem");
                });
                studentAvgList.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenStudentExplusionListWindow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (facultyDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = facultyDataGrid.ItemsSource as List<Models.Faculty>;
                var item = facultyDataGrid.SelectedItem as Models.Faculty;

                Windows.StudentExplusionList studentExplusionList = new Windows.StudentExplusionList(item.Id);
                studentExplusionList.Closed += new EventHandler((_s, _e) =>
                {
                    DirectoryFillTabItem("FacultyTabItem");
                });
                studentExplusionList.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AvgGradeOpenWindowButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Windows.SubjectAvarageGrades subjectAvarageGrades = new Windows.SubjectAvarageGrades();
                subjectAvarageGrades.Closed += new EventHandler((_s, _e) =>
                {
                    DirectoryFillTabItem("SubjectTabItem");
                });
                subjectAvarageGrades.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SubjectAddButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.Subject subject = new Windows.Subject();
            subject.Closed += new EventHandler((_s, _e) =>
            {
                DirectoryFillTabItem("SubjectTabItem");
            });
            subject.Show();
        }

        private void SubjectChangeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (subjectDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = subjectDataGrid.ItemsSource as List<Models.Subject>;
                var item = subjectDataGrid.SelectedItem as Models.Subject;

                Windows.Subject group = new Windows.Subject(item.Id);
                group.Closed += new EventHandler((_s, _e) =>
                {
                    DirectoryFillTabItem("SubjectTabItem");
                });
                group.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SubjectDeleteButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (subjectDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = subjectDataGrid.ItemsSource as List<Models.Subject>;
                var item = subjectDataGrid.SelectedItem as Models.Subject;

                using (DataContext db = new DataContext())
                {
                    if (db.StudentGrades.Where(x => x.SubjectId == item.Id).Count() > 0)
                        throw new ArgumentException("Выбранный вами предмет, удалить нельзя");

                    var subject = db.Subject.Find(item.Id);

                    db.Subject.Remove(subject);
                    db.SaveChanges();
                }

                items.Remove(item);
                DirectoryFillTabItem("SubjectTabItem");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StudentAddButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.Student student = new Windows.Student();
            student.Closed += new EventHandler((_s, _e) =>
            {
                DirectoryFillTabItem("StudentTabItem");
            });
            student.Show();
        }

        private void StudentChangeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (studentDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = studentDataGrid.ItemsSource as List<Models.Student>;
                var item = studentDataGrid.SelectedItem as Models.Student;

                Windows.Student student = new Windows.Student(item.Id);
                student.Closed += new EventHandler((_s, _e) =>
                {
                    DirectoryFillTabItem("StudentTabItem");
                });
                student.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StudentDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (studentDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = studentDataGrid.ItemsSource as List<Models.Student>;
                var item = studentDataGrid.SelectedItem as Models.Student;

                using (DataContext db = new DataContext())
                {
                    if (db.StudentGrades.Where(x => x.StudentId == item.Id).Count() > 0)
                        throw new ArgumentException("Выбранного вами студента, удалить нельзя");

                    var student = db.Student.Find(item.Id);

                    db.Student.Remove(student);
                    db.SaveChanges();
                }

                items.Remove(item);
                DirectoryFillTabItem("StudentTabItem");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NegativeGradesButton_Click(object sender, RoutedEventArgs e)
        {
            using(DataContext db = new DataContext())
            {
                int negativeGrades = 0;
                int count = 0;
                string nameOfSubject = "";
                foreach(var subject in db.Subject.ToList())
                {
                    foreach(var grade in db.StudentGrades.Where(x => x.SubjectId == subject.Id))
                    {
                        if(grade.Grade < 4)
                        {
                            count++;
                        }
                    }
                    if(count > negativeGrades)
                    {
                        negativeGrades = count;
                        nameOfSubject = subject.Name;
                    }
                }
                if(negativeGrades == 0)
                {
                    MessageBox.Show("По всем предметам удовлетворяющие оценки");
                }
                else
                {
                    MessageBox.Show($"Большое всего неудовлетворяющих оценок по предмету '{nameOfSubject}' их количество {negativeGrades}");
                }
            }
        }
    }
}

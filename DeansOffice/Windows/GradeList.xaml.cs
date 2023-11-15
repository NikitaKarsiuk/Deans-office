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
    /// Interaction logic for GradeList.xaml
    /// </summary>
    public partial class GradeList : Window
    {
        private int Id {get; set;}
        public GradeList(int Id)
        {

            InitializeComponent();
            this.Id = Id;
            using (DataContext db = new DataContext())
            {
                var items = db.StudentGrades.Where(x => x.StudentId == Id).ToList();
                gradeListDataGrid.ItemsSource = items;
            }
        }

        private void DirectoryFillTabItem()
        {
            using (DataContext db = new DataContext())
            {
                var items = db.StudentGrades.Where(x => x.StudentId == Id).ToList();
                gradeListDataGrid.ItemsSource = items;
                gradeListDataGrid.Items.Refresh();
            }
        }
        private void GradeAddButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.Grade grade = new Windows.Grade(Id);
            grade.Closed += new EventHandler((_s, _e) =>
            {
                DirectoryFillTabItem();
                this.Show();
            });
            grade.Show();
            this.Hide();
        }

        private void GradeChangeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (gradeListDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = gradeListDataGrid.ItemsSource as List<Models.StudentGrades>;
                var item = gradeListDataGrid.SelectedItem as Models.StudentGrades;

                Windows.Grade grade = new Windows.Grade(Id, item.Id);
                grade.Closed += new EventHandler((_s, _e) =>
                {
                    DirectoryFillTabItem();
                    this.Show();
                });
                grade.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GradeDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (gradeListDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");


                var items = gradeListDataGrid.ItemsSource as List<Models.StudentGrades>;
                var item = gradeListDataGrid.SelectedItem as Models.StudentGrades;

                using (DataContext db = new DataContext())
                {

                    var studentGrade = db.StudentGrades.Find(item.Id);

                    db.StudentGrades.Remove(studentGrade);
                    db.SaveChanges();
                }

                items.Remove(item);
                DirectoryFillTabItem();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}

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
    /// Interaction logic for SubjectList.xaml
    /// </summary>
    public partial class SubjectList : Window
    {
        private int Id { get; set; }
        public SubjectList(int Id = 1)
        {
            InitializeComponent();
            this.Id = Id;
            using(DataContext db = new DataContext())
            {
                var items = db.SubjectGroupList.Where(x => x.GroupId == Id).ToList();
                subjectListDataGrid.ItemsSource = items;
            }
        }

        private void DirectoryFillTabItem()
        {
            using (DataContext db = new DataContext())
            {
                var items = db.SubjectGroupList.Where(x => x.GroupId == Id).ToList();
                subjectListDataGrid.ItemsSource = items;
                subjectListDataGrid.Items.Refresh();
            }
        }

        private void SubjectAddButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.SubjectGroupList subject = new Windows.SubjectGroupList(Id);
            subject.Closed += new EventHandler((_s, _e) =>
            {
                DirectoryFillTabItem();
                this.Show();
            });
            subject.Show();
            this.Hide();
        }

        private void SubjectChangeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (subjectListDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = subjectListDataGrid.ItemsSource as List<Models.SubjectGroupList>;
                var item = subjectListDataGrid.SelectedItem as Models.SubjectGroupList;

                Windows.SubjectGroupList group = new Windows.SubjectGroupList(Id,item.Id);
                group.Closed += new EventHandler((_s, _e) =>
                {
                    DirectoryFillTabItem();
                    this.Show();
                });
                group.Show();
                this.Hide();
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
                if (subjectListDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");


                var items = subjectListDataGrid.ItemsSource as List<Models.SubjectGroupList>;
                var item = subjectListDataGrid.SelectedItem as Models.SubjectGroupList;

                using (DataContext db = new DataContext())
                {
                    if (db.StudentGrades.Where(x => x.SubjectId == item.Id).Count() > 0)
                        throw new ArgumentException("Выбранный вами предмет, удалить нельзя");

                    var subject = db.SubjectGroupList.Find(item.Id);

                    db.SubjectGroupList.Remove(subject);
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

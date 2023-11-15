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
    /// Interaction logic for StudentList.xaml
    /// </summary>
    public partial class StudentList : Window
    {
        private int Id { get; set; }
        public StudentList(int Id)
        {
            this.Id = Id;
            InitializeComponent();
            using (DataContext db = new DataContext())
            {
                var items = db.Student.Where(x => x.GroupId == Id).ToList();
                studentListDataGrid.ItemsSource = items;
                studentListDataGrid.Items.Refresh();
            }
        }

        private void OpenGradeWindow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (studentListDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var items = studentListDataGrid.ItemsSource as List<Models.Student>;
                var item = studentListDataGrid.SelectedItem as Models.Student;
                Windows.GradeList gradeList = new Windows.GradeList(item.Id);
                gradeList.Closed += new EventHandler((_s, _e) =>
                {
                    this.Show();
                });
                this.Hide();
                gradeList.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

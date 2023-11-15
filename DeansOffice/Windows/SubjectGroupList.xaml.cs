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
    /// Interaction logic for SubjectGroupList.xaml
    /// </summary>
    public partial class SubjectGroupList : Window
    {
        private int Id { get; set; }
        private int GroupId { get; set; }
        public SubjectGroupList(int GroupId, int Id = -1)
        {
            InitializeComponent();
            this.Id = Id;
            this.GroupId = GroupId;
            using (DataContext db = new DataContext())
            {
                NameComboBox.ItemsSource = db.Subject.ToList();

                if (Id != -1)
                {
                    var subjectGroupList = db.SubjectGroupList.Find(Id);
                    var item = db.Subject.Find(subjectGroupList.SubjectId);
                    NameComboBox.Text = item.Name;
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DataContext db = new DataContext())
                {
                    if (NameComboBox.Text == "")
                        throw new ArgumentException("Ошибка. Поле 'Предмет' не должно быть пустым");

                    var subjectGroupList = db.SubjectGroupList.Where(x => x.GroupId == GroupId).ToList();

                    if(Id == -1)
                    {
                        foreach(var item in subjectGroupList)
                        {
                            if(item.SubjectId == (NameComboBox.SelectedItem as Models.Subject).Id)
                            {
                                throw new ArgumentException("Ошибка. Предмет уже существует у данной группы");
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in subjectGroupList)
                        {
                            if (item.SubjectId == (NameComboBox.SelectedItem as Models.Subject).Id && Id != item.Id)
                            {
                                throw new ArgumentException("Ошибка. Предмет уже существует у данной группы");
                            }
                        }
                    }

                    if (Id == -1)
                    {
                        db.SubjectGroupList.Add(new Models.SubjectGroupList()
                        {
                            SubjectId = (NameComboBox.SelectedItem as Models.Subject).Id,
                            GroupId = GroupId
                        });
                    }
                    else
                    {
                        var subjectItem = db.SubjectGroupList.Find(Id);
                        subjectItem.SubjectId = (NameComboBox.SelectedItem as Models.Subject).Id;
                        subjectItem.GroupId = GroupId;

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

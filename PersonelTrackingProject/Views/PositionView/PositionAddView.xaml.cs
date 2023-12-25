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
using PersonelTrackingProject.DB;

namespace PersonelTrackingProject.Views.PositionView
{
    public partial class PositionAddView : Window
    {
        public PositionAddView()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (cmbDepartment.SelectedIndex == -1 || txtPosition.Text.Trim() == "" )
            {
                MessageBox.Show("Values Cannot be empty, please try again.");
            }
            else
            {
                Position positionNew = new Position();
                positionNew.PositionName = txtPosition.Text;
                positionNew.DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);
                db.Add(positionNew);
                db.SaveChanges();
                cmbDepartment.SelectedIndex = -1;
                txtPosition.Clear();
                MessageBox.Show("New Position saved.");
                //MessageBox.Show($"New Position saved {cmbDepartment.SelectedValue.ToString()}."); // 6
                //MessageBox.Show($"New Position saved {cmbDepartment.SelectedIndex.ToString()}."); // 2
                //MessageBox.Show($"New Position saved {cmbDepartment.SelectedItem.ToString()}."); // PersonelTrackingProject.DB.Department
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        PersoneltrackingContext db = new PersoneltrackingContext();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var listDepartments = db.Departments.OrderBy(x => x.DepartmentName).ToList();
            cmbDepartment.ItemsSource = listDepartments;
            cmbDepartment.DisplayMemberPath = "DepartmentName";
            cmbDepartment.SelectedValuePath = "Id";
            cmbDepartment.SelectedIndex = -1;
        }
    }
}

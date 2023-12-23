using PersonelTrackingProject.DB;
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

namespace PersonelTrackingProject.Views
{
    /// <summary>
    /// Interaction logic for DepartmentUpdateView.xaml
    /// </summary>
    public partial class DepartmentUpdateView : Window
    {
        public DepartmentUpdateView()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public Department departmentOrigin;

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtDepartmentName.Text.Trim().Length == 0)
            {
                MessageBox.Show("no empty fields");
            }
            else
            {
                using (PersoneltrackingContext db = new PersoneltrackingContext())
                {
                    Department departmentTemp = new Department();
                    departmentTemp.DepartmentName = txtDepartmentName.Text;
                    departmentTemp.Id = departmentOrigin.Id;
                    db.Update(departmentTemp);
                    db.SaveChanges();
                    MessageBox.Show("Department was updated successfully.");
                    //this.Close();
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Department departmentTemp = new Department();
            txtDepartmentName.Text = departmentOrigin.DepartmentName;
        }
    }
}

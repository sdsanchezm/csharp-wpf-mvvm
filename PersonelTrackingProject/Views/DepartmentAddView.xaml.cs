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

namespace PersonelTrackingProject.Views
{
    /// <summary>
    /// Interaction logic for DepartmentAddView.xaml
    /// </summary>
    public partial class DepartmentAddView : Window
    {
        public DepartmentAddView()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtDepartmentName.Text.Trim().Length == 0) 
            {
                MessageBox.Show("No empty fields allowed.");
            }
            else
            {
                using (PersoneltrackingContext db = new PersoneltrackingContext())
                {
                    Department department = new Department();
                    department.DepartmentName = txtDepartmentName.Text;
                    db.Add(department);
                    db.SaveChanges();
                    txtDepartmentName.Clear();
                    MessageBox.Show("New Department was added.");
                }
            }
        }
    }
}

using PersonelTrackingProject.DB;
using PersonelTrackingProject.Dtos;
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

namespace PersonelTrackingProject.Views.PositionView
{
    public partial class PositionUpdateView : Window
    {
        public PositionUpdateView()
        {
            InitializeComponent();
        }

        public PositionDepartmentDto modelPositionDepartment;
        PersoneltrackingContext db = new PersoneltrackingContext();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // get data from database
            var listDepartments = db.Departments.ToList().OrderBy(x => x.DepartmentName);
            // assign the list of Departments to the comboBox
            cmbDepartment.ItemsSource = listDepartments;
            // Set the property to show in the comboBox
            cmbDepartment.DisplayMemberPath = "DepartmentName";
            // Set the selected value, using the Id
            cmbDepartment.SelectedValuePath = "Id";
            // Set the actual selected element to the comboBox
            cmbDepartment.SelectedValue = modelPositionDepartment.DepartmentId;
            // Set the actual selected Text to the TextBox
            txtPosition.Text = modelPositionDepartment.PositionName;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtPosition.Text.Trim().Length == 0)
            {
                MessageBox.Show("No empty fields are allowed.");
            }
            else
            {
                using (PersoneltrackingContext db = new PersoneltrackingContext())
                {
                    Position positionTemp = new Position();
                    positionTemp.Id = modelPositionDepartment.PositionID;
                    positionTemp.PositionName = txtPosition.Text;
                    positionTemp.DepartmentId = (int)cmbDepartment.SelectedValue;
                    db.Positions.Update(positionTemp);
                    db.SaveChanges();
                    MessageBox.Show("The position was updated successfully.");
                    //this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

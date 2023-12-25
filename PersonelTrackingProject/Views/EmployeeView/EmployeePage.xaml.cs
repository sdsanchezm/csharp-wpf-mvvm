using Microsoft.Win32;
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
using PersonelTrackingProject.DB;
using System.IO;

namespace PersonelTrackingProject.Views.EmployeeView
{
    public partial class EmployeePage : Window
    {
        public EmployeePage()
        {
            InitializeComponent();
        }

        PersoneltrackingContext db = new PersoneltrackingContext();
        List<Position> positionsTemp = new List<Position>();
        OpenFileDialog dialogImage = new OpenFileDialog();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbDepartment.ItemsSource = db.Departments.ToList();
            cmbDepartment.DisplayMemberPath = "DepartmentName";
            cmbDepartment.SelectedValuePath = "Id";
            cmbDepartment.SelectedIndex = -1;
            positionsTemp = db.Positions.ToList();
            cmbPosition.ItemsSource = positionsTemp;
            cmbPosition.DisplayMemberPath = "PositionName";
            cmbPosition.SelectedValuePath = "Id";
            cmbPosition.SelectedIndex = -1;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(txtUserNo.Text.Trim() == "" || txtPassword.Text.Trim() == "" || txtName.Text.Trim() == "" ||  txtSurname.Text.Trim() == ""
                || txtSalary.Text.Trim() == "" || cmbDepartment.SelectedIndex == -1 || cmbPosition.SelectedIndex == -1)
            {
                MessageBox.Show("No Empty fields Allowed.");
            }
            else
            {
                Employee employeeNew = new Employee();
                employeeNew.UserNo = Convert.ToInt32(txtUserNo.Text);
                employeeNew.Password = txtPassword.Text;
                employeeNew.Name = txtName.Text;
                employeeNew.Surname = txtSurname.Text;
                employeeNew.Salary = Convert.ToInt32(txtSalary.Text);
                employeeNew.DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);
                employeeNew.PositionId = Convert.ToInt32(cmbPosition.SelectedValue);
                TextRange textAddress = new TextRange(txtAddress.Document.ContentStart, txtAddress.Document.ContentEnd);
                employeeNew.Address = textAddress.Text;
                employeeNew.IsAdmin = (bool)chisAdmin.IsChecked;
                string filenameImage = "";
                string uniqueName = Guid.NewGuid().ToString();
                filenameImage += uniqueName + dialogImage.SafeFileName;
                employeeNew.ImagePath = filenameImage;
                db.Employees.Add(employeeNew);
                db.SaveChanges();
                File.Copy(txtImage.Text, @"Images//" + filenameImage);
                MessageBox.Show("Employee was Added.");
                // clearing fields
                ClearFields();
            }
        }

        void ValidateFields()
        {
            // logic for fields validate
            // benefit: reduce spaguetti code in the btnSave method
        }

        void ClearFields()
        {
            txtUserNo.Clear();
            txtPassword.Clear();
            txtName.Clear();
            txtSurname.Clear();
            txtSalary.Clear();
            picker1.SelectedDate = DateTime.Today;
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.ItemsSource = positionsTemp;
            cmbPosition.SelectedIndex = -1;
            txtAddress.Document.Blocks.Clear();
            chisAdmin.IsChecked = false;
            EmployeeImage.Source = new BitmapImage();
            txtImage.Clear();
        }

        private void cmbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int departmentId = Convert.ToInt32(cmbDepartment.SelectedValue);
            if (cmbDepartment.SelectedIndex != -1)
            {
                cmbPosition.ItemsSource = positionsTemp.Where(p => p.DepartmentId == departmentId).ToList();
                cmbPosition.DisplayMemberPath = "PositionName";
                cmbPosition.SelectedValuePath = "Id";
                cmbPosition.SelectedIndex = -1;
            }
        }

        private void btnChoose_Click(object sender, RoutedEventArgs e)
        {
            if(dialogImage.ShowDialog() == true)
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(dialogImage.FileName);
                image.EndInit();
                EmployeeImage.Source = image;
                txtImage.Text = dialogImage.FileName;
            }
        }

        private void txtUserNo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            var userNumberTemp = Convert.ToInt32(txtUserNo.Text);
            var userNumberChecker = db.Employees.Where(u => u.UserNo == userNumberTemp).FirstOrDefault();
            if (userNumberChecker != null)
            {
                MessageBox.Show("User Number in use.");
            }
            else
            {
                MessageBox.Show("User Number is available.");
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PersonelTrackingProject.Views.EmployeeView
{
    /// <summary>
    /// Interaction logic for EmployeeListView.xaml
    /// </summary>
    public partial class EmployeeListView : UserControl
    {
        public EmployeeListView()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            EmployeePage windowNewEmployee = new EmployeePage();
            windowNewEmployee.Show();

        }

        PersoneltrackingContext db = new PersoneltrackingContext();
        List<Position> positionsTemp = new List<Position>();
        List<EmployeeDetailDto> listEmployees = new List<EmployeeDetailDto>();

        private void Control_Loaded(object sender, RoutedEventArgs e)
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
            listEmployees = db.Employees.Include(e => e.Position).Include(e => e.Department).Select(p => new EmployeeDetailDto()
            {
                Id = p.Id,
                UserNo = p.UserNo,
                Name = p.Name,
                Surname = p.Surname,
                PositionId = p.PositionId,
                PositionName = p.Position.PositionName,
                DepartmentId = p.DepartmentId,
                DepartmentName = p.Department.DepartmentName,
                Birthday = (DateTime)p.Birthday,
                isAdmin = p.IsAdmin,
                Salary = p.Salary,
                Password = p.Password,
                Address = p.Address,
            }).ToList();
            gridEmployee.ItemsSource = listEmployees;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            List<EmployeeDetailDto> searchedList = listEmployees;

            if (txtUserNumber.Text.Trim() != "")
                searchedList = searchedList.Where(p => p.UserNo == Convert.ToInt32(txtUserNumber.Text)).ToList();

            if (txtName.Text.Trim() != "")
                searchedList = searchedList.Where((p) => p.Name.Contains(txtName.Text)).ToList();

            if (txtSurname.Text.Trim() != "")
                searchedList = searchedList.Where(p => p.Surname.Contains(txtSurname.Text)).ToList();

            if (cmbDepartment.SelectedIndex != -1)
                searchedList = searchedList.Where(p => p.DepartmentId == Convert.ToInt32(cmbDepartment.SelectedValue)).ToList();

            if (cmbPosition.SelectedIndex != -1)
                searchedList = searchedList.Where(p => p.PositionId == Convert.ToInt32(cmbPosition.SelectedValue)).ToList();

            gridEmployee.ItemsSource = searchedList;
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

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtUserNumber.Clear();
            txtName.Clear();
            txtSurname.Clear();
            cmbPosition.SelectedIndex = -1;
            cmbPosition.ItemsSource = positionsTemp;
            cmbDepartment.SelectedIndex = -1;
            gridEmployee.ItemsSource= listEmployees;
        }
    }
}

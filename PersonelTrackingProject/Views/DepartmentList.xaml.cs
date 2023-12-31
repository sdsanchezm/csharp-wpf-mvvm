﻿using System;
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
using PersonelTrackingProject.DB;

namespace PersonelTrackingProject.Views
{
    public partial class DepartmentList : UserControl
    {
        public DepartmentList()
        {
            InitializeComponent();
            using(PersoneltrackingContext db = new PersoneltrackingContext())
            {
                List<Department> departmentList = db.Departments.OrderBy(d => d.DepartmentName).ToList();
                gridDepartment.ItemsSource = departmentList;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DepartmentAddView departmentWindow = new DepartmentAddView();
            departmentWindow.ShowDialog();
            using (PersoneltrackingContext db = new PersoneltrackingContext())
            {
                List<Department> departmentsList = db.Departments.OrderBy(d => d.DepartmentName).ToList();
                gridDepartment.ItemsSource = departmentsList;
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Department departmentSelected = (Department)gridDepartment.SelectedItem;
            DepartmentUpdateView departmentUpdateView = new DepartmentUpdateView();
            departmentUpdateView.departmentOrigin = departmentSelected;
            departmentUpdateView.ShowDialog();
            using (PersoneltrackingContext db = new PersoneltrackingContext())
            {
                List<Department> departmentsList = db.Departments.OrderBy(d => d.DepartmentName).ToList();
                gridDepartment.ItemsSource = departmentsList;
            }
        }
    }
}

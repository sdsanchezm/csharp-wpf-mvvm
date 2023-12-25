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
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PersonelTrackingProject.DB;
using PersonelTrackingProject.Dtos;

namespace PersonelTrackingProject.Views.PositionView
{
    public partial class PositionList : UserControl
    {
        public PositionList()
        {
            InitializeComponent();
        }

        PersoneltrackingContext db = new PersoneltrackingContext();

        private void PositionList_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateGridData();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            PositionAddView windowNewPosition = new PositionAddView();
            windowNewPosition.Show();
            UpdateGridData();
        }

        void UpdateGridData()
        {
            var listPositionDepartment = (
            from position in db.Positions
            join department in db.Departments on position.DepartmentId equals department.Id
            select new PositionDepartmentDto
            {
                PositionID = position.Id,
                PositionName = position.PositionName,
                DepartmentId = position.DepartmentId,
                DepartmentName = department.DepartmentName
            }
            ).ToList();

            //List<PositionDepartmentDto> modelList = new List<PositionDepartmentDto>();

            //foreach ( var item in listPositionDepartment )
            //{
            //    PositionDepartmentDto model = new PositionDepartmentDto();
            //    model.PositionID = item.PositionID;
            //    model.PositionName = item.PositionName;
            //    model.DepartmentId = item.DepartmentId;
            //    model.DepartmentName = item.DepartmentName;
            //    modelList.Add( model );
            //}

            gridPosition.ItemsSource = listPositionDepartment;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            // getting PositionDepartment from the datagrid using the Dto
            PositionDepartmentDto selectedPosition = (PositionDepartmentDto)gridPosition.SelectedItem;
            // validating if the selection is empty
            if (selectedPosition != null && selectedPosition.PositionID != 0)
            {
                PositionUpdateView windowUpdatePosition = new PositionUpdateView();
                windowUpdatePosition.modelPositionDepartment = selectedPosition;
                windowUpdatePosition.Show();
                UpdateGridData();
            }
        }
    }
}

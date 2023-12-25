using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelTrackingProject.Dtos
{
    public class PositionDepartmentDto
    {
        public int PositionID { get; set; }
        public string PositionName { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}

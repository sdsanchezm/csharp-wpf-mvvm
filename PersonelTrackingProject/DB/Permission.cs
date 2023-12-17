using System;
using System.Collections.Generic;

namespace PersonelTrackingProject.DB;

public partial class Permission
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public DateTime PermissionStartDate { get; set; }

    public DateTime PermissionEndDate { get; set; }

    public int PermissionState { get; set; }

    public string PermissionExplanation { get; set; } = null!;

    public int PermissionDay { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Permissionstate PermissionStateNavigation { get; set; } = null!;
}

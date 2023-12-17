using System;
using System.Collections.Generic;

namespace PersonelTrackingProject.DB;

public partial class Permissionstate
{
    public int Id { get; set; }

    public string StateName { get; set; } = null!;

    public virtual ICollection<Permission> Permissions { get; } = new List<Permission>();
}

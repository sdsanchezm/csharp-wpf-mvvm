using System;
using System.Collections.Generic;

namespace PersonelTrackingProject.DB;

public partial class Taskstate
{
    public int Id { get; set; }

    public string StateName { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; } = new List<Task>();
}

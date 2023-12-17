﻿using System;
using System.Collections.Generic;

namespace PersonelTrackingProject.DB;

public partial class Task
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public string TaskTitle { get; set; } = null!;

    public string TaskContent { get; set; } = null!;

    public DateTime TaskStartDate { get; set; }

    public DateTime TaskDeliveryDate { get; set; }

    public int TaskState { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Taskstate TaskStateNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace PersonelTrackingProject.DB;

public partial class Employee
{
    public int Id { get; set; }

    public int UserNo { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string ImagePath { get; set; } = null!;

    public int DepartmentId { get; set; }

    public int PositionId { get; set; }

    public int Salary { get; set; }

    public DateTime Birthday { get; set; }

    public string Address { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsAdmin { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Permission> Permissions { get; } = new List<Permission>();

    public virtual Position Position { get; set; } = null!;

    public virtual ICollection<Salary> Salaries { get; } = new List<Salary>();

    public virtual ICollection<Task> Tasks { get; } = new List<Task>();
}

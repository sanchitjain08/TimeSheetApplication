using System;
using System.Collections.Generic;

namespace TimeSheetApplication.Models;

public partial class Employee
{
    public string EmployeeEmail { get; set; } = null!;

    public string EmployeePassword { get; set; } = null!;

    public int EmployeeId { get; set; }

    public string EmployeeFirstName { get; set; } = null!;

    public string? EmployeeLastName { get; set; }

    public string EmployeeDesignation { get; set; } = null!;

    public DateTime EmployeeJoiningDate { get; set; }

    public DateTime? EmployeeLeavingDate { get; set; }

    public byte? EmployeeStatus { get; set; }

    public virtual ICollection<TaskList> TaskLists { get; } = new List<TaskList>();

    public virtual ICollection<TimeSheet> TimeSheets { get; } = new List<TimeSheet>();
}

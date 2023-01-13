using System;
using System.Collections.Generic;

namespace TimeSheetApplication.Models;

public partial class TimeSheet
{
    public int TimeSheetId { get; set; }

    public string EmployeeEmail { get; set; } = null!;

    public int TaskId { get; set; }

    public byte? ApprovalStatus { get; set; }

    public virtual Employee EmployeeEmailNavigation { get; set; } = null!;

    public virtual TaskList Task { get; set; } = null!;
}

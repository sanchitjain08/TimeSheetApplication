using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace TimeSheetApplication.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public partial class TaskList
{
    [Key]
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TaskId { get; set; }

    public string EmployeeEmail { get; set; } = null!;

    public string TaskDetails { get; set; } = null!;

    public DateTime TaskCraeted { get; set; }

    public DateTime TaskDeadline { get; set; }

    public DateTime? TaskCompletion { get; set; }

    public byte TaskType { get; set; }

    public virtual Employee EmployeeEmailNavigation { get; set; } = null!;

    public virtual ICollection<TimeSheet> TimeSheets { get; } = new List<TimeSheet>();
}

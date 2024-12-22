using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class TaskStatus
{
    public int Id { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<TaskStatusHistory> TaskStatusHistoryNewStatuses { get; set; } = new List<TaskStatusHistory>();

    public virtual ICollection<TaskStatusHistory> TaskStatusHistoryOldStatuses { get; set; } = new List<TaskStatusHistory>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}

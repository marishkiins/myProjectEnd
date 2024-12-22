using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class TaskPrioritiesHistory
{
    public int Id { get; set; }

    public int TaskId { get; set; }

    public int OldPriority { get; set; }

    public int NewPriority { get; set; }

    public DateTime ChangedAt { get; set; }

    public virtual TaskPriority NewPriorityNavigation { get; set; } = null!;

    public virtual TaskPriority OldPriorityNavigation { get; set; } = null!;

    public virtual Task Task { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class TaskStatusHistory
{
    public int Id { get; set; }

    public int TaskId { get; set; }

    public int OldStatusId { get; set; }

    public int NewStatusId { get; set; }

    public DateTime? ChangedAt { get; set; }

    public virtual TaskStatus NewStatus { get; set; } = null!;

    public virtual TaskStatus OldStatus { get; set; } = null!;

    public virtual Task Task { get; set; } = null!;
}

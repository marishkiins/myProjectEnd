using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class TaskComment
{
    public int Id { get; set; }

    public int TaskId { get; set; }

    public string Comment { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual Task Task { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class ShortTaskDescription
{
    public int TaskId { get; set; }

    public string Description { get; set; } = null!;

    public virtual Task Task { get; set; } = null!;
}

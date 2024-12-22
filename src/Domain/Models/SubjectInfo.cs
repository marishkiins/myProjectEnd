using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class SubjectInfo
{
    public int SubjectId { get; set; }

    public int TeacherId { get; set; }

    public string? Classroom { get; set; }

    public virtual Subject Subject { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}

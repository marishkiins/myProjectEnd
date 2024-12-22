using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Subject
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string SubjectName { get; set; } = null!;

    public virtual SubjectInfo? SubjectInfo { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}

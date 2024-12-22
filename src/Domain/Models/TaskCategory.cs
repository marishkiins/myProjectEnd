using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class TaskCategory
{
    public int Id { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}

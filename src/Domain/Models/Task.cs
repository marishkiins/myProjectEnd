using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Task
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int TypeId { get; set; }

    public int PriorityId { get; set; }

    public int StatusId { get; set; }

    public int? SubjectId { get; set; }

    public int CategoryId { get; set; }

    public string Description { get; set; } = null!;

    public DateTime Deadline { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual TaskCategory Category { get; set; } = null!;

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual TaskPriority Priority { get; set; } = null!;

    public virtual ShortTaskDescription? ShortTaskDescription { get; set; }

    public virtual TaskStatus Status { get; set; } = null!;

    public virtual Subject? Subject { get; set; }

    public virtual ICollection<TaskAttachment> TaskAttachments { get; set; } = new List<TaskAttachment>();

    public virtual ICollection<TaskComment> TaskComments { get; set; } = new List<TaskComment>();

    public virtual ICollection<TaskPrioritiesHistory> TaskPrioritiesHistories { get; set; } = new List<TaskPrioritiesHistory>();

    public virtual ICollection<TaskStatusHistory> TaskStatusHistories { get; set; } = new List<TaskStatusHistory>();

    public virtual TaskType Type { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

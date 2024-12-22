using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Notification
{
    public int Id { get; set; }

    public int TaskId { get; set; }

    public DateTime NotificationTime { get; set; }

    public int StatusId { get; set; }

    public virtual NotificationStatus Status { get; set; } = null!;

    public virtual Task Task { get; set; } = null!;
}

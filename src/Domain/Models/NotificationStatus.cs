using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class NotificationStatus
{
    public int Id { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}

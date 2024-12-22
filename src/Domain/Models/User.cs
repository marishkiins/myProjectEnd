using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual RolesOfUser? RolesOfUser { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    public virtual UserInfo? UserInfo { get; set; }
}

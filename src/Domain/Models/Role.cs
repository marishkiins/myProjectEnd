using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Role
{
    public int Id { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<RolesOfUser> RolesOfUsers { get; set; } = new List<RolesOfUser>();
}

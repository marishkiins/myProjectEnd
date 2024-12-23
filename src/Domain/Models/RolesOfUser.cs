﻿using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class RolesOfUser
{
    public int UserId { get; set; }

    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

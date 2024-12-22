using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class UserInfo
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public string PlaceOfStudy { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

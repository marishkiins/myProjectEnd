using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<SubjectInfo> SubjectInfos { get; set; } = new List<SubjectInfo>();
}

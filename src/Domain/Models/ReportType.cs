using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class ReportType
{
    public int Id { get; set; }

    public string ReportTypeName { get; set; } = null!;

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
}

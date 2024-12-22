using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Report
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ReportTypeId { get; set; }

    public DateOnly ReportPeriodStart { get; set; }

    public DateOnly ReportPeriodEnd { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ReportType ReportType { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

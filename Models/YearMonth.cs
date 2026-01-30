using System;

namespace JobTracker2.Models;

public class YearMonth
{
    public int YearMonthId { get; set; }
    public string YearId { get; set; } = string.Empty;
    public Year Year { get; set; } = null!;

    public int MonthId { get; set; }
    public Month Month { get; set; } = null!;
}

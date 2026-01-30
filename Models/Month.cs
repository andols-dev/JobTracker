using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobTracker2.Models
{
    public class Month
    {
        public int MonthId { get; set; }

        [DisplayName("Month")]
        [Column("Month")]
        public string? Mon { get; set; }

        public List<Job> Jobs { get; set; } = new List<Job>();

        public List<YearMonth> YearMonths { get; set; } = new List<YearMonth>();
    }
}

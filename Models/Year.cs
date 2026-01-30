using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobTracker2.Models
{
    public class Year
    {
        public string YearId { get; set; } = string.Empty;

        [DisplayName("Year")]
        [Column("Year")]
        public int? Yr { get; set; }

        public List<YearMonth> YearMonths { get; set; } = new List<YearMonth>();
    }
}

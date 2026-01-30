using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace JobTracker2.Models
{
    public class Job
    {
        public int JobId { get; set; }

        [Required]
        public DateTime Date { get; set; }
        [Required]

        public string Company { get; set; } = string.Empty;
        [Required]

        public string Position { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        public int MonthId { get; set; }

        [ValidateNever]
        public Month Month { get; set; } = null!;

        public string YearId { get; set; } = string.Empty;
        [ValidateNever]
        public Year Year { get; set; } = null!;


    }
}

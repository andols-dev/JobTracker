using JobTracker2.Models;
using Microsoft.EntityFrameworkCore;

namespace JobTracker2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Year> Years { get; set; } = null!;

        public DbSet<Month> Months { get; set; } = null!;

        public DbSet<Job> Jobs { get; set; } = null!;

        public DbSet<YearMonth> YearMonths { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=JobTrackerdatabase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Year>().HasData(
                new Year { YearId = "2025", Yr = 2025 },
                new Year { YearId = "2026", Yr = 2026 }
            );
            modelBuilder.Entity<Month>().HasData(
                new Month { MonthId = 1, Mon = "January" },
                new Month { MonthId = 2, Mon = "February" },
                new Month { MonthId = 3, Mon = "March" },
                new Month { MonthId = 4, Mon = "April" },
                new Month { MonthId = 5, Mon = "May" },
                new Month { MonthId = 6, Mon = "June" },
                new Month { MonthId = 7, Mon = "July" },
                new Month { MonthId = 8, Mon = "August" },
                new Month { MonthId = 9, Mon = "September" },
                new Month { MonthId = 10, Mon = "October" },
                new Month { MonthId = 11, Mon = "November" },
                new Month { MonthId = 12, Mon = "December" }
            );

            modelBuilder.Entity<YearMonth>().HasData(
                new YearMonth { YearMonthId = 1, YearId = "2025", MonthId = 12 },
                new YearMonth { YearMonthId = 2, YearId = "2026", MonthId = 1 },
                new YearMonth { YearMonthId = 3, YearId = "2026", MonthId = 2 },
                new YearMonth { YearMonthId = 4, YearId = "2026", MonthId = 3 },
                new YearMonth { YearMonthId = 5, YearId = "2026", MonthId = 4 },
                new YearMonth { YearMonthId = 6, YearId = "2026", MonthId = 5 },
                new YearMonth { YearMonthId = 7, YearId = "2026", MonthId = 6 },
                new YearMonth { YearMonthId = 8, YearId = "2026", MonthId = 7 },
                new YearMonth { YearMonthId = 9, YearId = "2026", MonthId = 8 },
                new YearMonth { YearMonthId = 10, YearId = "2026", MonthId = 9 },
                new YearMonth { YearMonthId = 11, YearId = "2026", MonthId = 10 },
                new YearMonth { YearMonthId = 12, YearId = "2026", MonthId = 11 },
                new YearMonth { YearMonthId = 13, YearId = "2026", MonthId = 12 }
            );

            modelBuilder.Entity<Job>().HasData(
                new Job
                {
                    JobId = 1,
                    Date = new DateTime(2025, 12, 15),
                    Company = "TechCorp",
                    Position = "Software Engineer",
                    City = "New York",
                    MonthId = 12,
                    YearId = "2025"
                },
                new Job
                {
                    JobId = 2,
                    Date = new DateTime(2026, 1, 10),
                    Company = "Innovatech",
                    Position = "Data Analyst",
                    City = "San Francisco",
                    MonthId = 1,
                    YearId = "2026"
                }
            );

        }
    }
}

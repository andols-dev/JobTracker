using System;
using JobTracker2.Data;
using JobTracker2.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace JobTracker2.Functions;

public static class HelperService
{
    public static async Task<JobsViewModel> GetJobsViewModel(string yearId, int monthId, AppDbContext _db)
    {

        var viewModel = new JobsViewModel
        {

            Jobs = await _db.Jobs
            .Where(j => j.YearId == yearId && j.MonthId == monthId)
            .ToListAsync(),
            GroupedByCityList = await _db.Jobs
                .Where(j => j.YearId == yearId && j.MonthId == monthId)
                .GroupBy(j => j.City)
                .Select(g => new DTOs.GroupByCityDTO
                {
                    City = g.Key,
                    Count = g.Count()
                })
                .ToListAsync(),
            GroupedByPositionList = await _db.Jobs
                .Where(j => j.YearId == yearId && j.MonthId == monthId)
                .GroupBy(j => j.Position)
                .Select(g => new DTOs.GroupByPositionDTO
                {
                    Position = g.Key,
                    Count = g.Count()
                })
                .ToListAsync()
        };

        return viewModel;
    }
    public static async Task<int> GetTotalJobsForYear(string yearId, AppDbContext _db)
    {
        return await _db.Jobs.CountAsync(j => j.YearId == yearId);
    }
}

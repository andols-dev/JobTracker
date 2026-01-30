using System.Security.Cryptography.X509Certificates;
using JobTracker2.Data;
using JobTracker2.Models;
using JobTracker2.Functions;
using JobTracker2.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobTracker2.Controllers
{
    public class YearController : Controller
    {
        private readonly AppDbContext _db;

        public YearController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var years = await _db.Years.ToListAsync();
            return View(years);
        }

        [Microsoft.AspNetCore.Mvc.Route("Year/{yearId}")]

        public async Task<IActionResult> Months(string yearId)
        {
            var yearMonths = await _db.YearMonths
                .Include(ym => ym.Month)
                .Where(ym => ym.YearId == yearId)
                .ToListAsync();

            ViewBag.YearId = yearId; // Pass the YearId to the view for reference
            var totalJobs = await HelperService.GetTotalJobsForYear(yearId, _db);
            ViewBag.TotalJobs = totalJobs; // Pass total jobs to the view
            return View(yearMonths);
        }


        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("Year/{yearId}/Month/{monthId}")]
        public async Task<IActionResult> Jobs(string yearId, int monthId)
        {
            var viewModel = await HelperService.GetJobsViewModel(yearId, monthId, _db);
            ViewBag.YearId = yearId;
            ViewBag.MonthId = monthId;
            // month name for display
            var month = await _db.Months.FindAsync(monthId);
            ViewBag.MonthName = month?.Mon;
            return View(viewModel);
        }




        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("Year/{yearId}/Month/{monthId}/CreateJob")]
        public async Task<IActionResult> CreateJob(string yearId, int monthId)
        {
            ViewBag.YearId = yearId;
            ViewBag.MonthId = monthId;
            return View();
        }


        // function that creates an applied job
        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("Year/{yearId}/Month/{monthId}/CreateJob")]
        public async Task<IActionResult> CreateJob(Job job)
        {
            var errors = ModelState.Values.ToList();
            if (ModelState.IsValid)
            {
                _db.Jobs.Add(job);
                TempData["message"] = "Job added successfully";
                await _db.SaveChangesAsync();
                return RedirectToAction("Jobs", new { YearId = job.YearId, MonthId = job.MonthId });
            }
            return View(job);
        }

        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("Year/{yearId}/Month/{monthId}/DeleteJob/{jobId}")]
        public async Task<IActionResult> DeleteJob(int jobId)
        {
            var jobToDelete = _db.Jobs.Find(jobId);
            if (jobToDelete != null)
            {
                _db.Jobs.Remove(jobToDelete);
                await _db.SaveChangesAsync();
                TempData["message"] = "Job removed successfully";
            }
            return RedirectToAction("Jobs", new { YearId = jobToDelete?.YearId, MonthId = jobToDelete?.MonthId });
        }
    }
}

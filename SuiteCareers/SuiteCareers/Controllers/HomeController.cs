using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SuiteCareers.Models;
using SuiteCareers.Data;
using Microsoft.EntityFrameworkCore;
using SuiteCareers.ViewModels;
using System.TimeSpan;

namespace SuiteCareers.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private SuiteCareersDbContext _db;

    public HomeController(ILogger<HomeController> logger, SuiteCareersDbContext db)
    {
        _db = db;
        _logger = logger;
    }
    [HttpGet]
    public IActionResult Index()
    {
        var AverageSessionLength = _db.Sessions.Where(b => b.EndDate != null)
                                                .Average(b => b.EndDate - b.StartDate);
        var dashboardVM = new ViewModels.DashboardVM
        {
            /*SnapshotBar*/
            NewUser = _db.Users.Where(b => b.CreateDate >= DateTime.Today.AddDays(-7)).Count(),
            TotalUsers = _db.Users.Count(),
            AvgSessionLength = _db.Sessions.Where(b => b.EndDate != null)
                                    .Average(b => (b.EndDate! - b.StartDate)!
                                    .TotalMinutes),
            TotalSessions = _db.Sessions.Count(),
            QuestionsAnswered = _db.Responses.Count(),
            NewQuestions = _db.Questions.Where(b => b.CreateDate >= DateTime.Today.AddDays(-7)).Count(),

            /*ActiveUsers Info*/
            /*ActiveUsers =*/
            ActiveSessions = _db.Sessions.Count(b => b.EndDate == null),

            /*Tables*/
            RecentSessions = _db.Sessions.Include(b => b.User).OrderByDescending(b => b.EndDate).Take(5).ToList(),

            TopQuestions = _db.Questions.Include(b => b.Responses)                              
                                .OrderByDescending(b => b.Responses.Count())
                                .Take(5)
                                .ToList(),

        };
        
        return View(dashboardVM);
    }

    [HttpPost]
    public IActionResult DashboardFilter(DashboardVM dashboardVM) { 
            
            return View(dashboardVM);
    }

    public IActionResult Questions()
    {
        return View();
    }

    public IActionResult Sessions()
    {
        return View();
    }

    public IActionResult Users()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}


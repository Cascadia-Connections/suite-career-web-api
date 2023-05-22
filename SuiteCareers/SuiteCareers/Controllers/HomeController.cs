using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SuiteCareers.Models;
using SuiteCareers.Data;
using Microsoft.EntityFrameworkCore;
using SuiteCareers.ViewModels;

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

    public IActionResult Index()
    {

        var RecentSession = new ViewModels.RecentSession
        {
            RecentSessions = _db.Sessions.OrderBy(b => b.Date).Take(5).OrderByDescending(b => b.Date).ToList(),
        };

        var dashboardVM = new ViewModels.DashboardVM
        {
            NewUser = _db.UserDescriptions.Where(b => b.Date >= DateTime.Today.AddDays(-7)).Count(),
            TotalUsers = _db.Users.Count(),
            /*AvgSessionLength = */
            TotalSessions = _db.Sessions.Count(),
            /*QuestionsAnswered =*/
            /*NewQuestions = _db.Questions.Where(b => b.Date >= DateTime.Today.AddDays(-7)).Count(),*/

            /*ActiveUsers =*/
            /*ActiveSessions = */
            RecentSessions = (IEnumerable<RecentSession>)RecentSession
        };
        
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


using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SuiteCareers.Models;
using SuiteCareers.Data;
using Microsoft.EntityFrameworkCore;
using SuiteCareers.ViewModels;
using System.Linq;

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
        var dashboardVM = new ViewModels.DashboardVM
        {
            /*SnapshotBar*/
            NewUser = _db.Users.Where(b => b.CreateDate >= DateTime.Today.AddDays(-7))
                               .Count(),
            TotalUsers = _db.Users.Count(),
            AvgSessionLength = _db.Sessions
                                .Where(b => b.EndDate.HasValue)
                                .ToList()
                                .Average(b => (b.EndDate.Value - b.StartDate).TotalMinutes),
            TotalSessions = _db.Sessions
                                .Count(),
            QuestionsAnswered = _db.Responses
                                .Count(),
            NewQuestions = _db.Questions
                                .Where(b => b.CreateDate >= DateTime.Today.AddDays(-7))
                                .Count(),

            /*ActiveUsers Info*/
            ActiveUsers = _db.Users
                                .Count(b => b.ActivityStatus == true),
            ActiveSessions = _db.Sessions
                                .Count(b => b.EndDate == null),

            /*Tables*/
            RecentSessions = _db.Sessions
                                .Include(b => b.User)
                                .OrderByDescending(b => b.EndDate)
                                .Take(5)
                                .ToList(),

            TopQuestions = _db.Questions
                                .Include(b => b.Responses)                              
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

    public IActionResult Sessions(
    string term = "",
    string orderBy = "",
    int currentPage = 1,
    DateTime? start = null,
    DateTime? end = null
)
    {
        term = string.IsNullOrEmpty(term) ? "" : term.ToLower();
        var sessionData = new SessionsVM();

        sessionData.UserSortParm = orderBy == "user" ? "user_desc" : "user";
        sessionData.DateSortParm = orderBy == "date" ? "date_desc" : "date";
        sessionData.TimeSortParm = orderBy == "time" ? "time_desc" : "time";
        sessionData.SessionIDSortParm = orderBy == "session_id" ? "session_id_desc" : "session_id";

        var sessions = _db.Sessions.Where(session =>
        (term == "" ||
        session.User.LastName.ToLower().StartsWith(term) ||
        session.User.FirstName.ToLower().StartsWith(term) ||
        session.SessionId.ToString().StartsWith(term)) &&
        (!start.HasValue || session.StartDate >= start.Value) &&
        (!end.HasValue || session.StartDate <= end.Value))
        .Select(session => new Session()
        {
            SessionId = session.SessionId,
            StartDate = session.StartDate,
            EndDate = session.EndDate,
            User = session.User
        });

        switch (orderBy)
        {
            case "user":
                sessions = sessions.OrderBy(s => s.User.LastName).ThenBy(s => s.User.FirstName);
                break;
            case "user_desc":
                sessions = sessions.OrderByDescending(s => s.User.LastName).ThenBy(s => s.User.FirstName);
                break;
            case "session_id_desc":
                sessions = sessions.OrderByDescending(s => s.SessionId);
                break;
            case "session_id":
                sessions = sessions.OrderBy(s => s.SessionId);
                break;
            case "date":
                sessions = sessions.OrderBy(s => s.StartDate);
                break;
            case "time":
                sessions = sessions.OrderBy(s => s.StartDate.TimeOfDay);
                break;
            case "time_desc":
                sessions = sessions.OrderByDescending(s => s.StartDate.TimeOfDay);
                break;
            default:
                sessions = sessions.OrderByDescending(s => s.StartDate);
                break;
        }
        int totalRecords = sessions.Count();
        int pageSize = 10;
        int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
        sessions = sessions.Skip((currentPage - 1) * pageSize).Take(pageSize);
        sessionData.Sessions = sessions;
        sessionData.CurrentPage = currentPage;
        sessionData.TotalPages = totalPages;
        sessionData.Term = term;
        sessionData.PageSize = pageSize;
        sessionData.OrderBy = orderBy;
        sessionData.Start = start;
        sessionData.End = end;
        return View(sessionData);
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


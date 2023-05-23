using Microsoft.AspNetCore.Mvc;
using SuiteCareers.Data;
using SuiteCareers.Models;
using System.Diagnostics;

namespace SuiteCareers.Controllers
{

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
            return View();
        }

        public IActionResult Questions()
        {
            return View();
        }

        public IActionResult UserDemographics()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }
        /* [HttpGet]*/
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

            sessionData.UserSortParm = String.IsNullOrEmpty(orderBy) ? "user_desc" : "";
            sessionData.UserSortParm = orderBy == "user" ? "user_desc" : "user";
            sessionData.DateSortParm = orderBy == "date" ? "date_desc" : "date";
            sessionData.TimeSortParm = orderBy == "time" ? "time_desc" : "time";
            sessionData.SessionIDSortParm = orderBy == "session_id" ? "session_id_desc" : "session_id";

            var sessions = _db.Sessions.Where(session =>
            (term == "" ||
            session.User.LastName.ToLower().StartsWith(term) ||
            session.User.FirstName.ToLower().StartsWith(term) ||
            session.SessionId.ToString().StartsWith(term)) &&
            (!start.HasValue || session.Date >= start.Value) &&
            (!end.HasValue || session.Date <= end.Value))
            .Select(session => new Session
            {
                SessionId = session.SessionId,
                Date = session.Date,
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
                    sessions = sessions.OrderBy(s => s.Date);
                    break;
                case "time":
                    sessions = sessions.OrderBy(s => s.Date.TimeOfDay);
                    break;
                case "time_desc":
                    sessions = sessions.OrderByDescending(s => s.Date.TimeOfDay);
                    break;
                default:
                    sessions = sessions.OrderByDescending(s => s.Date);
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
            return View(sessionData);
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
}


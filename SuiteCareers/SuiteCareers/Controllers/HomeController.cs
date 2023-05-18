using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Sessions(string sortOrder)
        {
            ViewBag.UserSortParm = sortOrder == "user" ? "user_desc" : "user";
            ViewBag.DateSortParm = sortOrder == "date" ? "date_desc" : "date";
            ViewBag.TimeSortParm = sortOrder == "time" ? "time_desc" : "time";
            ViewBag.SessionIDSortParm = sortOrder == "session_id" ? "session_id_desc" : "session_id";
            IEnumerable<Session> sessions = _db.Sessions.Include(s => s.User);
            switch (sortOrder)
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
            return View(sessions.ToList());
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


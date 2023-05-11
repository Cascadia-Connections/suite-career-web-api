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

        public IActionResult UserAnalytics()
        {
            return View();
        }

        public IActionResult UserDemographics()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Sessions()
        {
            IQueryable<Session> allSessions = _db.Sessions.Include(s => s.User).OrderByDescending(s => s.Date);
            return View(allSessions);
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


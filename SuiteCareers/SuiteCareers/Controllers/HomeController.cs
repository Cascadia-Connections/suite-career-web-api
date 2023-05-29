﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SuiteCareers.Models;
using SuiteCareers.Data;
using Microsoft.EntityFrameworkCore;

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
        return View();
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


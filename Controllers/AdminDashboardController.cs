using DKRSLandingPage_WebApp.Data;
using Microsoft.AspNetCore.Mvc;
using DKRSLandingPage_WebApp.Filters;

namespace DKRSLandingPage_WebApp.Controllers;

[AdminAuthorize]
public class AdminDashboardController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminDashboardController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        ViewBag.ProjectCount = _context.Projects.Count();

        ViewBag.CustomerCount = _context.CustomerLeads.Count();

        var latestCustomers = _context.CustomerLeads
            .OrderByDescending(x => x.CreatedAt)
            .Take(5)
            .ToList();

        return View(latestCustomers);
    }
}
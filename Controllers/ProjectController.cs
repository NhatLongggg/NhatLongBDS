using DKRSLandingPage_WebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DKRSLandingPage_WebApp.Controllers;

public class ProjectController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProjectController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var projects = _context.Projects.ToList();

        return View(projects);
    }

    public IActionResult Details(int id)
    {
        var project = _context.Projects
            .Include(x => x.Images)
            .FirstOrDefault(x => x.Id == id);

        if (project == null)
            return NotFound();

        return View(project);
    }

    [Route("du-an/{slug}")]
    public IActionResult Detail(string slug)
    {
        var project = _context.Projects
            .Include(x => x.Facilities)
            .Include(x => x.Images)
            .FirstOrDefault(x => x.Slug == slug);

        if (project == null)
            return NotFound();

        return View("Details", project);
    }
}
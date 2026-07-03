using DKRSLandingPage_WebApp.Data;
using DKRSLandingPage_WebApp.Models;
using DKRSLandingPage_WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using DKRSLandingPage_WebApp.Filters;

namespace DKRSLandingPage_WebApp.Controllers;

[AdminAuthorize]
public class AdminProjectFacilityController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminProjectFacilityController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index(int projectId)
    {
        var project = _context.Projects.FirstOrDefault(x => x.Id == projectId);

        if (project == null)
            return NotFound();

        ViewBag.ProjectId = project.Id;
        ViewBag.ProjectName = project.Name;
        ViewBag.ProjectLocation = project.Location;
        ViewBag.ProjectThumbnail = project.Thumbnail;

        var facilities = _context.ProjectFacilities
            .Where(x => x.ProjectId == projectId)
            .ToList();

        return View(facilities);
    }

    public IActionResult Create(int projectId)
    {
        var project = _context.Projects.FirstOrDefault(x => x.Id == projectId);

        if (project == null)
            return NotFound();

        ViewBag.ProjectName = project.Name;
        ViewBag.ProjectLocation = project.Location;
        ViewBag.ProjectThumbnail = project.Thumbnail;

        return View(new ProjectFacilityViewModel
        {
            ProjectId = projectId
        });
    }

    [HttpPost]
    public IActionResult Create(ProjectFacilityViewModel model)
    {
        var facility = new ProjectFacility
        {
            ProjectId = model.ProjectId,
            Name = model.Name
        };

        _context.ProjectFacilities.Add(facility);

        _context.SaveChanges();

        TempData["Success"] = "Thêm tiện ích thành công!";

        return RedirectToAction("Index", new { projectId = model.ProjectId });
    }

    public IActionResult Edit(int id)
    {
        var facility = _context.ProjectFacilities
            .FirstOrDefault(x => x.Id == id);

        if (facility == null)
            return NotFound();

        var project = _context.Projects
            .FirstOrDefault(x => x.Id == facility.ProjectId);

        ViewBag.ProjectName = project?.Name;
        ViewBag.ProjectLocation = project?.Location;
        ViewBag.ProjectThumbnail = project?.Thumbnail;

        return View(new ProjectFacilityViewModel
        {
            Id = facility.Id,
            ProjectId = facility.ProjectId,
            Name = facility.Name
        });
    }

    [HttpPost]
    public IActionResult Edit(ProjectFacilityViewModel model)
    {
        var facility = _context.ProjectFacilities
            .FirstOrDefault(x => x.Id == model.Id);

        if (facility == null)
            return NotFound();

        facility.Name = model.Name;

        _context.SaveChanges();

        TempData["Success"] = "Cập nhật tiện ích thành công!";

        return RedirectToAction("Index",
            new { projectId = facility.ProjectId });
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var facility = _context.ProjectFacilities
            .FirstOrDefault(x => x.Id == id);

        if (facility == null)
            return NotFound();

        var projectId = facility.ProjectId;

        _context.ProjectFacilities.Remove(facility);

        _context.SaveChanges();

        TempData["Success"] = "Đã xóa tiện ích.";

        return RedirectToAction("Index",
            new { projectId });
    }
}
using DKRSLandingPage_WebApp.Data;
using DKRSLandingPage_WebApp.Models;
using DKRSLandingPage_WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using DKRSLandingPage_WebApp.Filters;

namespace DKRSLandingPage_WebApp.Controllers;

[AdminAuthorize]
public class AdminProjectImageController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminProjectImageController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index(int projectId)
    {
        var project = _context.Projects
            .FirstOrDefault(x => x.Id == projectId);

        if (project == null)
            return NotFound();

        ViewBag.ProjectId = projectId;
        ViewBag.ProjectName = project.Name;
        ViewBag.ProjectLocation = project.Location;
        ViewBag.ProjectThumbnail = project.Thumbnail;

        var images = _context.ProjectImages
            .Where(x => x.ProjectId == projectId)
            .ToList();

        return View(images);
    }

    public IActionResult Create(int projectId)
    {
        var project = _context.Projects
            .FirstOrDefault(x => x.Id == projectId);

        if (project == null)
            return NotFound();

        ViewBag.ProjectName = project.Name;
        ViewBag.ProjectLocation = project.Location;
        ViewBag.ProjectThumbnail = project.Thumbnail;

        return View(new ProjectImageCreateViewModel
        {
            ProjectId = projectId
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProjectImageCreateViewModel model)
    {
        if (model.ImageFile == null)
            return View(model);

        var project = _context.Projects
            .FirstOrDefault(x => x.Id == model.ProjectId);

        if (project == null)
            return NotFound();

        // Thư mục theo Slug
        var folder = Path.Combine(
            Directory.GetCurrentDirectory(),
            "wwwroot",
            "images",
            project.Slug);

        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);

        // Tên file
        var fileName = Guid.NewGuid() +
                       Path.GetExtension(model.ImageFile.FileName);

        var filePath = Path.Combine(folder, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await model.ImageFile.CopyToAsync(stream);
        }

        var image = new ProjectImage
        {
            ProjectId = model.ProjectId,
            ImageUrl = "/images/" + project.Slug + "/" + fileName
        };

        _context.ProjectImages.Add(image);

        await _context.SaveChangesAsync();

        TempData["Success"] = "Upload ảnh thành công!";

        return RedirectToAction(
            "Index",
            new { projectId = model.ProjectId });
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var image = _context.ProjectImages
            .FirstOrDefault(x => x.Id == id);

        if (image == null)
            return NotFound();

        var projectId = image.ProjectId;

        _context.ProjectImages.Remove(image);

        _context.SaveChanges();

        return RedirectToAction(
            "Index",
            new { projectId });
    }
}
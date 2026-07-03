using DKRSLandingPage_WebApp.Data;
using DKRSLandingPage_WebApp.Models;
using DKRSLandingPage_WebApp.Services;
using DKRSLandingPage_WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using DKRSLandingPage_WebApp.Filters;

namespace DKRSLandingPage_WebApp.Controllers;

[AdminAuthorize]
public class AdminProjectController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ImageUploadService _imageUploadService;

    public AdminProjectController(
        ApplicationDbContext context,
        ImageUploadService imageUploadService)
    {
        _context = context;
        _imageUploadService = imageUploadService;
    }

    public IActionResult Index()
    {
        var projects = _context.Projects.ToList();

        return View(projects);
    }

    public IActionResult Create()
    {
        return View(new ProjectViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProjectViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var project = new Project
        {
            Name = model.Name,
            Slug = model.Slug,
            Developer = model.Developer,
            Location = model.Location,
            PriceFrom = model.PriceFrom,
            Description = model.Description
        };

        project.Thumbnail = await _imageUploadService.UploadAsync(
            model.ThumbnailFile,
            project.Slug) ?? "";

        project.BannerImage = await _imageUploadService.UploadAsync(
            model.BannerFile,
            project.Slug) ?? "";

        project.LocationImage = await _imageUploadService.UploadAsync(
            model.LocationImageFile,
            project.Slug) ?? "";

        _context.Projects.Add(project);

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var project = _context.Projects.Find(id);

        if (project == null)
            return NotFound();

        var model = new ProjectViewModel
        {
            Id = project.Id,
            Name = project.Name,
            Slug = project.Slug,
            Developer = project.Developer,
            Location = project.Location,
            PriceFrom = project.PriceFrom,
            Description = project.Description,

            Thumbnail = project.Thumbnail,
            BannerImage = project.BannerImage,
            LocationImage = project.LocationImage
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProjectViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var project = _context.Projects.Find(model.Id);

        if (project == null)
            return NotFound();

        project.Name = model.Name;
        project.Slug = model.Slug;
        project.Developer = model.Developer;
        project.Location = model.Location;
        project.PriceFrom = model.PriceFrom;
        project.Description = model.Description;

        if (model.ThumbnailFile != null)
            project.Thumbnail = await _imageUploadService.UploadAsync(
                model.ThumbnailFile,
                project.Slug) ?? project.Thumbnail;

        if (model.BannerFile != null)
            project.BannerImage = await _imageUploadService.UploadAsync(
                model.BannerFile,
                project.Slug) ?? project.BannerImage;

        if (model.LocationImageFile != null)
            project.LocationImage = await _imageUploadService.UploadAsync(
                model.LocationImageFile,
                project.Slug) ?? project.LocationImage;

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var project = _context.Projects.Find(id);

        if (project == null)
            return NotFound();

        _context.Projects.Remove(project);

        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
}
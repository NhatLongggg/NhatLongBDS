using DKRSLandingPage_WebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DKRSLandingPage_WebApp.Filters;


namespace DKRSLandingPage_WebApp.Controllers;


[AdminAuthorize]
public class AdminCustomerLeadController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminCustomerLeadController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var leads = _context.CustomerLeads
            .Include(x => x.Project)
            .OrderByDescending(x => x.CreatedAt)
            .ToList();

        return View(leads);
    }
    
    public IActionResult Details(int id)
    {
        var lead = _context.CustomerLeads
            .Include(x => x.Project)
            .FirstOrDefault(x => x.Id == id);

        if (lead == null)
            return NotFound();

        return View(lead);
    }
    
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var lead = _context.CustomerLeads
            .FirstOrDefault(x => x.Id == id);

        if (lead == null)
            return NotFound();

        _context.CustomerLeads.Remove(lead);

        _context.SaveChanges();

        TempData["Success"] = "Đã xóa khách hàng thành công.";

        return RedirectToAction(nameof(Index));
    }
}
using DKRSLandingPage_WebApp.Data;
using DKRSLandingPage_WebApp.Models;
using DKRSLandingPage_WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DKRSLandingPage_WebApp.Controllers;

public class LeadController : Controller
{
    private readonly ApplicationDbContext _context;

    public LeadController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Create(CustomerLeadViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new
            {
                success = false,
                message = "Dữ liệu không hợp lệ."
            });
        }

        var project = _context.Projects
            .FirstOrDefault(x => x.Id == model.ProjectId);

        if (project == null)
        {
            return NotFound(new
            {
                success = false,
                message = "Không tìm thấy dự án."
            });
        }

        var lead = new CustomerLead
        {
            FullName = model.FullName,
            Phone = model.Phone,
            Message = model.Message,
            ProjectId = model.ProjectId
        };

        _context.CustomerLeads.Add(lead);

        _context.SaveChanges();

        return Json(new
        {
            success = true,
            message = "Gửi yêu cầu thành công!"
        });
    }
    
    
}
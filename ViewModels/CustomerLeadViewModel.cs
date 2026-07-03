using System.ComponentModel.DataAnnotations;

namespace DKRSLandingPage_WebApp.ViewModels;

public class CustomerLeadViewModel
{
    [Required]
    public string FullName { get; set; } = "";

    [Required]
    public string Phone { get; set; } = "";

    public string? Message { get; set; }

    public int ProjectId { get; set; }
}
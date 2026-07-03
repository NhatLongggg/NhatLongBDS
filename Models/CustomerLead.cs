using System.ComponentModel.DataAnnotations;

namespace DKRSLandingPage_WebApp.Models;

public class CustomerLead
{
    public int Id { get; set; }

    [Required]
    public string FullName { get; set; } = "";

    [Required]
    public string Phone { get; set; } = "";

    public string? Message { get; set; }

    public int ProjectId { get; set; }

    public Project? Project { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
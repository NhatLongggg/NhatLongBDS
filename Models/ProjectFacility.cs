namespace DKRSLandingPage_WebApp.Models;

public class ProjectFacility
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public string Name { get; set; } = "";

    public Project Project { get; set; }
}
namespace DKRSLandingPage_WebApp.Models;

public class Project
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public string Slug { get; set; } = "";

    public string Developer { get; set; } = "";

    public string Location { get; set; } = "";

    public decimal PriceFrom { get; set; }

    public string Thumbnail { get; set; } = "";

    public string BannerImage { get; set; } = "";

    public string Description { get; set; } = "";

    public string GoogleMapUrl { get; set; } = "";

    public string LocationImage { get; set; } = "";

    public List<ProjectImage> Images { get; set; } = new();

    public List<ProjectFacility> Facilities { get; set; } = new();
    
    public ICollection<CustomerLead> CustomerLeads { get; set; }
        = new List<CustomerLead>();
}
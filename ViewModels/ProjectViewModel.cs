namespace DKRSLandingPage_WebApp.ViewModels;

public class ProjectViewModel
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public string Slug { get; set; } = "";

    public string Developer { get; set; } = "";

    public string Location { get; set; } = "";

    public decimal PriceFrom { get; set; }

    public string Description { get; set; } = "";

    public IFormFile? ThumbnailFile { get; set; }

    public IFormFile? BannerFile { get; set; }

    public IFormFile? LocationImageFile { get; set; }
    
    public string? Thumbnail { get; set; }

    public string? BannerImage { get; set; }

    public string? LocationImage { get; set; }
}
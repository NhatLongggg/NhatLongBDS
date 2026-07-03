using DKRSLandingPage_WebApp.Models;

namespace DKRSLandingPage_WebApp.Services;

public static class ProjectService
{
    public static List<Project> GetProjects()
    {
        return new List<Project>
        {
            new()
            {
                Id = 1,
                Name = "The Emerald Boulevard",
                Slug = "the-emerald-boulevard",
                Location = "Quốc Lộ 13",
                PriceFrom = 8000000000,
                Thumbnail = "/images/the-emerald-boulevard.jpg",
                Description = "Căn hộ cao cấp."
            },

            new()
            {
                Id = 2,
                Name = "The Emerald Garden View",
                Slug = "the-emerald-garden-view",
                Location = "Thuận An",
                PriceFrom = 5000000000,
                Thumbnail = "/images/THE-EMERALD-GARDEN-VIEW.jpg",
                Description = "Căn hộ cao cấp."
            },

            new()
            {
                Id = 3,
                Name = "The Emerald River Park",
                Slug = "the-emerald-riverpark",
                Location = "Lái Thiêu",
                PriceFrom = 3000000000,
                Thumbnail = "/images/the-emerald-river-park.jpg",
                Description = "Căn hộ cao cấp."
            }
        };
    }
}
using DKRSLandingPage_WebApp.Models;

namespace DKRSLandingPage_WebApp.Data;

public static class DbInitializer
{
    public static void Seed(ApplicationDbContext context)
    {
        if (context.Projects.Any())
            return;

        context.Projects.AddRange(
            new Project
            {
                Name = "The Emerald Boulevard",
                Slug = "the-emerald-boulevard",
                Developer = "Lê Phong Group",
                Location = "Quốc Lộ 13",
                LocationImage = "/images/The-Emerald-Boulevard/the-emerald-boulevard-location.jpg",
                PriceFrom = 8000000000,
                Thumbnail = "/images/The-Emerald-Boulevard/the-emerald-boulevard.jpg",
                BannerImage = "/images/The-Emerald-Boulevard/THE-EMERALD-GARDEN-VIEW.jpg",
                Description = "Căn hộ cao cấp.",
                GoogleMapUrl = ""
            },
            new Project
            {
                Name = "The Emerald Garden View",
                Slug = "the-emerald-garden-view",
                Developer = "Lê Phong Group",
                Location = "Quốc Lộ 13",
                LocationImage = "/images/The-Emerald-Garden-View/garden-view-location.jpg",
                PriceFrom = 8000000000,
                Thumbnail = "/images/The-Emerald-Garden-View/THE-EMERALD-GARDEN-VIEW.jpg",
                BannerImage = "/images/The-Emerald-Garden-View/THE-EMERALD-GARDEN-VIEW.jpg",
                Description = "Căn hộ cao cấp.",
                GoogleMapUrl = ""
            },
            new Project
            {
                Name = "The Emerald River Park",
                Slug = "the-emerald-river-park",
                Developer = "Lê Phong Group",
                Location = "Lái Thiêu",
                LocationImage = "/images/The-Emerald-River-Park/river-park-location.jpg",
                PriceFrom = 3000000000,
                Thumbnail = "/images/The-Emerald-River-Park/the-emerald-river-park.jpg",
                BannerImage = "/images/The-Emerald-River-Park/THE-EMERALD-GARDEN-VIEW.jpg",
                Description = "Căn hộ cao cấp.",
                GoogleMapUrl = ""
            }
        );

        context.SaveChanges();
    }
}
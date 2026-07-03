using DKRSLandingPage_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DKRSLandingPage_WebApp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Project> Projects { get; set; }

    public DbSet<ProjectImage> ProjectImages { get; set; }

    public DbSet<ProjectFacility> ProjectFacilities { get; set; }
    
    public DbSet<CustomerLead> CustomerLeads { get; set; }
}
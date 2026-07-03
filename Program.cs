using Microsoft.EntityFrameworkCore;
using DKRSLandingPage_WebApp.Data;
using DKRSLandingPage_WebApp.Services;
using System.IO;


var builder = WebApplication.CreateBuilder(args);

var dbPath = builder.Environment.IsDevelopment()
    ? Path.Combine(builder.Environment.ContentRootPath, "nhatlongrealestate.db")
    : Path.Combine(builder.Environment.ContentRootPath, "App_Data", "nhatlongrealestate.db");

Directory.CreateDirectory(Path.GetDirectoryName(dbPath)!);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite($"Data Source={dbPath}");
});

builder.Services.AddScoped<ImageUploadService>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

var app = builder.Build();

using(var scope=app.Services.CreateScope())
{
    var db = scope.ServiceProvider
        .GetRequiredService<ApplicationDbContext>();

    db.Database.Migrate();

    DbInitializer.Seed(db);
}
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler(
        "/Home/Error"); // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseSession();
app.UseAuthorization();
app.MapStaticAssets();
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}").WithStaticAssets();
app.Run();
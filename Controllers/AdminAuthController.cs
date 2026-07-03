using DKRSLandingPage_WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace DKRSLandingPage_WebApp.Controllers;

public class AdminAuthController : Controller
{
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        if (model.Username == "admin" &&
            model.Password == "123456")
        {
            HttpContext.Session.SetString(
                "AdminLoggedIn",
                "true");

            HttpContext.Session.SetString(
                "AdminName",
                "Nguyễn Nhất Long");

            return RedirectToAction(
                "Index",
                "AdminDashboard");
        }

        ViewBag.Error = "Sai tài khoản hoặc mật khẩu.";

        return View(model);
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();

        return RedirectToAction(nameof(Login));
    }
}
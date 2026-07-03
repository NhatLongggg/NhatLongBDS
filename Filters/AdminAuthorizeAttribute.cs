using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DKRSLandingPage_WebApp.Filters;

public class AdminAuthorizeAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var loggedIn =
            context.HttpContext.Session.GetString("AdminLoggedIn");

        if (loggedIn != "true")
        {
            context.Result = new RedirectToActionResult(
                "Login",
                "AdminAuth",
                null);
        }

        base.OnActionExecuting(context);
    }
}
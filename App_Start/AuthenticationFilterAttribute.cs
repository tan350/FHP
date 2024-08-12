using System.Reflection;
using System.Web;
using System.Web.Mvc;

public class AuthenticationFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        bool isAuthenticated = HttpContext.Current.Session["IsAuthenticated"] as bool? ?? false;
        bool isLoginPage = filterContext.HttpContext.Request.Url.AbsolutePath.ToLower().Contains("/userauthentication/index");

        if (!isAuthenticated && !isLoginPage)
        {
            filterContext.Result = new RedirectResult("~/UserAuthentication/Index");
        }
        else
        {
            return;
        }
    }
}

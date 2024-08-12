using System.Web;
using System.Web.Mvc;

namespace FHPNew.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
           /* filters.Add(new AuthenticationFilterAttribute());*/
            filters.Add(new HandleErrorAttribute());
        }
    }
}

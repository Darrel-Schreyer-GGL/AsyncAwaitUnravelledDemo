using System.Web;
using System.Web.Mvc;

namespace AsyncAwaitUnravelled.AspNetApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

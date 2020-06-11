using System.Web;
using System.Web.Mvc;

namespace LoginAndRegister_.NetFrameworkMVC_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

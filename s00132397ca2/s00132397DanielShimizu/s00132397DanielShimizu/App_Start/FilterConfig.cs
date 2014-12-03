using System.Web;
using System.Web.Mvc;

namespace s00132397DanielShimizu
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
using System.Web;
using System.Web.Mvc;

namespace JsonPatchInAspNet5.OldMvcClient
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

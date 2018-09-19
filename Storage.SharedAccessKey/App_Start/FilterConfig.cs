using System.Web;
using System.Web.Mvc;

namespace Storage.SharedAccessKey
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

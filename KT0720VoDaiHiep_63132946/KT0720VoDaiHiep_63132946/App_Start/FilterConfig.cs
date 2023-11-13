using System.Web;
using System.Web.Mvc;

namespace KT0720VoDaiHiep_63132946
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

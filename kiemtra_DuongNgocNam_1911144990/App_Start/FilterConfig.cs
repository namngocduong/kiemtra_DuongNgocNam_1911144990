using System.Web;
using System.Web.Mvc;

namespace kiemtra_DuongNgocNam_1911144990
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

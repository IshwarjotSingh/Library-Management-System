using System.Web;
using System.Web.Mvc;

namespace Final_Project_DotNet_Lasalle_College
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

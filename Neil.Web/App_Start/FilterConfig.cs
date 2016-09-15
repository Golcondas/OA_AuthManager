using Neil.Web.Models;
using System.Web;
using System.Web.Mvc;

namespace Neil.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new MyExceptionAttribute());//自定义异常过滤器
        }
    }
}
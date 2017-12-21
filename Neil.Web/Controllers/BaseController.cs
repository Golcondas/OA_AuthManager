using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Neil.Web.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 方法过滤器的方法
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        } 
    }
}

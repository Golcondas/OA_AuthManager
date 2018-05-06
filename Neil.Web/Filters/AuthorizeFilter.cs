using Neil.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Neil.Web.Filters
{
    /// <summary>
    /// 权限拦截
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizeFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
            var path = filterContext.HttpContext.Request.Path.ToLower();
            if (path == "/" || path.Equals("/Login/Index", StringComparison.CurrentCultureIgnoreCase) ||
                path.Equals("/Unauthorized", StringComparison.CurrentCultureIgnoreCase) ||
                path.Equals("/SignOut", StringComparison.CurrentCultureIgnoreCase)
                )
                return;//忽略对Login登录页的权限判定

            if (!filterContext.HttpContext.Request.HttpMethod.Equals("GET", StringComparison.CurrentCultureIgnoreCase)) return;

            //var control = filterContext.Controller as BaseController;
            //var userId = control.CurrentUserId;
            //if (string.IsNullOrEmpty(userId)) return;
            //var user = control.GetCurrentAccountModel();
            //if (user == null || user.IsAdmin) return;
            //var url = filterContext.HttpContext.Request.Url.AbsolutePath;
            //var hasPermission = PermissionClient.GetPermissionForCurrentUser(int.Parse(userId), url);
            //if (!hasPermission.IsSuccess)
            //{
            //    filterContext.Result = new RedirectResult("/Account/Unauthorized");
            //}
        }
    }
}
using Neil.Commom;
using Neil.Commom.ConfigKey;
using Neil.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Neil.Web.Controllers
{
    public class BaseController : Controller
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger("BaseController");
        public UserInfo userInfoBase { get; set; }

        /// <summary>
        /// 方法过滤器的方法
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //bool isExit = false;

            //if (Request.Cookies[CookieKey.neilCookie] != null)
            //{
            //    var sessionid = Request.Cookies[CookieKey.neilCookie].Value;
            //    var userInfo = RedisHelper.GetString(sessionid);
            //    if (!String.IsNullOrEmpty(userInfo))
            //    {
            //        userInfoBase = Neil.Commom.JsonHelper.JsonToObject<UserInfo>(userInfo);
            //        if (userInfoBase != null)
            //        {
            //            isExit = true;
            //        }
            //    }
            //}
            //if (isExit)
            //{
            //    filterContext.Result = new RedirectResult("/Login/Index");
            //    base.OnActionExecuted(filterContext);
            //    return;
            //}

            //base.OnActionExecuted(filterContext);
            //return;
        }
    }
}

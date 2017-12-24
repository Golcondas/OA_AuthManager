using Neil.Commom;
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
        /// <summary>
        /// 方法过滤器的方法
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string sessionid = Request.Cookies["neilCookie"] + "";
            var userInfo = RedisHelper.GetString(sessionid);
            if (string.IsNullOrWhiteSpace(userInfo))
            {
                UserInfo model = Neil.Commom.JsonHelper.JsonToObject<UserInfo>(userInfo);
            }
            base.OnActionExecuted(filterContext);
        } 
    }
}

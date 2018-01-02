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
            bool isExit = false;

            if (Request.Cookies[CookieKey.neilCookie] != null)
            {
                var sessionid = Request.Cookies[CookieKey.neilCookie].Value;
                var userInfo = RedisHelper.GetString(sessionid);
                if (!String.IsNullOrEmpty(userInfo))
                {
                    userInfoBase = Neil.Commom.JsonHelper.JsonToObject<UserInfo>(userInfo);
                    if (userInfoBase != null)
                    {
                        isExit = true;
                    }
                }
            }
            if (isExit)
            {

                filterContext.HttpContext.Response.Clear();//这里是关键，清除在返回前已经设置好的标头信息，这样后面的跳转才不会报错
                filterContext.HttpContext.Response.BufferOutput = true;//设置输出缓冲
                if (!filterContext.HttpContext.Response.IsRequestBeingRedirected)//在跳转之前做判断,防止重复
                {
                    filterContext.HttpContext.Response.Redirect("~/HuiUi/Admin/index.html", true);
                }
            }

            base.OnActionExecuted(filterContext);
        }

        public void RedirectUrl(string url)
        {

        }
    }

}

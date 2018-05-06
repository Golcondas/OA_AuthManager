using Neil.Commom;
using Neil.Commom.ConfigKey;
using Neil.Model;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Neil.Web.Controllers
{
    public class BaseController : Controller
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger("BaseController");
        public UserInfo userInfoBase { get; set; }

        public string CurrentUserId { get; set; }

        /// <summary>
        /// 方法过滤器的方法
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnAuthentication(System.Web.Mvc.Filters.AuthenticationContext filterContext)
        {
            try
            {
                if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
                {
                    if (filterContext.HttpContext.Request.IsAuthenticated)
                    {
                        //获取认证信息，然后获取到用户ID
                        HttpCookie authCookie = filterContext.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
                        FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                        CurrentUserId = authTicket.UserData;
                        //这里获取一下登录用户，如果没有用户的话，就跳转到登录页
                        //获取方式包括从缓存中读取，如果缓存没有的话，就从数据库中读取，如果数据库中都没有的话，就证明这个Key是过期或者伪造的，不能正常登录了
                        //var tempUser = GetCurrentAccountModel();
                        //如果用户不存在，就跳转到登录页面
                        var userInfo = RedisHelper.GetString(CurrentUserId);
                        if (!String.IsNullOrEmpty(userInfo))
                        {
                            var userInfoBase = Neil.Commom.JsonHelper.JsonToObject<UserInfo>(userInfo);
                            if (userInfoBase == null)
                            {
                                filterContext.Result = new RedirectResult("/Login/Index");
                                base.OnAuthentication(filterContext);
                                return;
                            }
                            //如果认证通过，并且用户在缓存或者数据库中存在的话，就跳转到主页
                            filterContext.Result = new RedirectResult("/Home/Index");
                        }
                    }
                    base.OnAuthentication(filterContext);
                    return;
                }

                //if(!filterContext.HttpContext.Request.IsAuthenticated)
                //{
                //    //跳转到登录页面
                //    filterContext.Result = new RedirectResult("/Login/Index");
                //}
                //else
                //{
                //    HttpCookie authCookie = filterContext.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
                //    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                //    CurrentUserId = authTicket.UserData;
                //}

                //if (string.IsNullOrEmpty(CurrentUserId))
                //{
                //    filterContext.Result = new RedirectResult("/Login/Index");
                //    base.OnAuthentication(filterContext);
                //    return;
                //}

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
                //        else
                //        {
                //            filterContext.Result = new RedirectResult("/Login/Index");
                //            base.OnAuthentication(filterContext);
                //            return;
                //        }
                //    }
                //}
                //if (isExit)
                //{

                //    //filterContext.HttpContext.Response.Clear();//这里是关键，清除在返回前已经设置好的标头信息，这样后面的跳转才不会报错
                //    //filterContext.HttpContext.Response.BufferOutput = true;//设置输出缓冲
                //    if (!filterContext.HttpContext.Response.IsRequestBeingRedirected)//在跳转之前做判断,防止重复
                //    {
                //        //filterContext.HttpContext.Response.Redirect("~/HuiUi/Admin/index.html", true);
                //        //TODO:不能直接跳转页面,需要跳转控制器
                //        //如果认证通过，并且用户在缓存或者数据库中存在的话，就跳转到主页
                //        filterContext.Result = new RedirectResult("/Home/Index");
                //    }
                //}
                base.OnAuthentication(filterContext);
                return;
            }
            catch
            {
                filterContext.Result = new RedirectResult("/Account/Login");
            }
            base.OnAuthentication(filterContext);
        }

        /// <summary>
        /// 第二
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.HttpMethod.Equals("GET", StringComparison.CurrentCultureIgnoreCase))
            {
                var url = filterContext.HttpContext.Request.Url;
            }
            base.OnAuthorization(filterContext);
        }
    }

}

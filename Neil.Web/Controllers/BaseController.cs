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

                if(!filterContext.HttpContext.Request.IsAuthenticated)
                {
                    //跳转到登录页面
                    filterContext.Result = new RedirectResult("/Login/Index");
                }
                else
                {
                    HttpCookie authCookie = filterContext.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                    CurrentUserId = authTicket.UserData;
                }

                if (string.IsNullOrEmpty(CurrentUserId))
                {
                    filterContext.Result = new RedirectResult("/Login/Index");
                    base.OnAuthentication(filterContext);
                    return;
                }

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
                        else
                        {
                            filterContext.Result = new RedirectResult("/Login/Index");
                            base.OnAuthentication(filterContext);
                            return;
                        }
                    }
                }
                if (isExit)
                {

                    //filterContext.HttpContext.Response.Clear();//这里是关键，清除在返回前已经设置好的标头信息，这样后面的跳转才不会报错
                    //filterContext.HttpContext.Response.BufferOutput = true;//设置输出缓冲
                    if (!filterContext.HttpContext.Response.IsRequestBeingRedirected)//在跳转之前做判断,防止重复
                    {
                        //filterContext.HttpContext.Response.Redirect("~/HuiUi/Admin/index.html", true);
                        //TODO:不能直接跳转页面,需要跳转控制器
                        //如果认证通过，并且用户在缓存或者数据库中存在的话，就跳转到主页
                        filterContext.Result = new RedirectResult("/Home/Index");
                    }
                }

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

        ///// <summary>
        ///// 获取当前用户的实体对象
        ///// </summary>
        ///// <returns></returns>
        //public UserInfo GetCurrentAccountModel()
        //{
        //    if (string.IsNullOrEmpty(CurrentUserId))
        //    {
        //        return null;
        //    }
        //    var key = Madison.Cache.CacheKeys.MANAGEMENTUSER + CurrentUserId;
        //    var user = Madison.Cache.MadisoncachedClient.Instance.Get<Madison.Model.Management.UserInfo>(key);
        //    if (user == null)
        //    {
        //        user = new Madison.Model.Management.UserInfo();
        //        int tempId = 0;
        //        if (int.TryParse(CurrentUserId, out tempId))
        //        {
        //            user.ID = int.Parse(CurrentUserId);
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //        user = UserInfoClient.GetUserByAccountId(user).Data;
        //    }
        //    return user;
        //} 


        ///// <summary>
        ///// Action级别
        ///// </summary>
        ///// <param name="filterContext"></param>
        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    //var user = GetCurrentAccountModel();
        //    //if (filterContext.HttpContext.Request.HttpMethod.Equals("GET", StringComparison.CurrentCultureIgnoreCase))
        //    //{
        //    //    var url = filterContext.HttpContext.Request.Url;
        //    //}


        //    ////CheckPermision(string CurrentUserId,string url);
        //    ////filterContext.HttpContext.Request.Url.AbsolutePath;
        //    //base.OnActionExecuting(filterContext);



        //    if (filterContext == null)
        //    {
        //        throw new ArgumentNullException("filterContext");
        //    }
        //    var path = filterContext.HttpContext.Request.Path.ToLower();
        //    if (path == "/" || path.Equals("/account/login", StringComparison.CurrentCultureIgnoreCase) ||
        //        path.Equals("/Account/Unauthorized", StringComparison.CurrentCultureIgnoreCase) ||
        //        path.Equals("/Account/SignOut", StringComparison.CurrentCultureIgnoreCase)
        //        )
        //        return;//忽略对Login登录页的权限判定

        //    var control = filterContext.Controller as BaseValidation;
        //    var userId = control.CurrentUserId;

        //    HttpCookie currentCookie = System.Web.HttpContext.Current.Request.Cookies.Get("currentCookieName");
        //    #region 登录过滤
        //    string key = CacheConfig.GetCacheKey(CacheConfig.AccountLoginLimit, CacheConfig.AccountLoginTypeManagement, control.CurrentUserId);
        //    string currentToken = Madison.Cache.MadisoncachedClient.Instance.Get<string>(key);
        //    string currentCookieValue = currentCookie.Value;

        //    log.DebugFormat("LoginFilter currentToken:{0},currentCookieValue:{1}", currentToken, currentCookieValue);
        //    if (!string.IsNullOrEmpty(currentToken) && !string.IsNullOrEmpty(currentCookieValue))
        //    {
        //        if (!currentToken.Equals(currentCookieValue))
        //        {
        //            System.Web.Security.FormsAuthentication.SignOut();
        //            //filterContext.Result = new RedirectResult("~/Account/Login");
        //            return;
        //        }
        //    }
        //    #endregion

        //    if (!filterContext.HttpContext.Request.HttpMethod.Equals("GET", StringComparison.CurrentCultureIgnoreCase)) return;

        //    //var control = filterContext.Controller as BaseValidation;
        //    //var userId = control.CurrentUserId;
        //    if (string.IsNullOrEmpty(userId)) return;
        //    var user = control.GetCurrentAccountModel();
        //    if (user == null || user.IsAdmin) return;
        //    var url = filterContext.HttpContext.Request.Url.AbsolutePath;

        //    SocketResponse hasPermission = CheckActionPermission(user.LoginName, userId, url);
        //    if (!hasPermission.IsSuccess)
        //    {
        //        filterContext.Result = new RedirectResult("/Account/Unauthorized");
        //    }
        //}

        ///// <summary>
        ///// 获取当前用户的实体对象
        ///// </summary>
        ///// <returns></returns>
        //public Madison.Model.Management.UserInfo GetCurrentAccountModel()
        //{
        //    if (string.IsNullOrEmpty(CurrentUserId))
        //    {
        //        return null;
        //    }
        //    var key = Madison.Cache.CacheKeys.MANAGEMENTUSER + CurrentUserId;
        //    var user = Madison.Cache.MadisoncachedClient.Instance.Get<Madison.Model.Management.UserInfo>(key);
        //    if (user == null)
        //    {
        //        user = new Madison.Model.Management.UserInfo();
        //        int tempId = 0;
        //        if (int.TryParse(CurrentUserId, out tempId))
        //        {
        //            user.ID = int.Parse(CurrentUserId);
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //        user = UserInfoClient.GetUserByAccountId(user).Data;
        //    }
        //    return user;
        //}

        //public new JsonResult Json(object data)
        //{
        //    return new JsonNetResult(data);
        //}


        //TODO:需要，移除缓存
        ///// <summary>
        ///// 移除正在登录的用户
        ///// </summary>
        ///// <returns></returns>
        //public bool RemoveOnlineUserAuth(int userId)
        //{
        //    var key = Madison.Cache.CacheKeys.MANAGEMENTUSER + userId;
        //    var user = Madison.Cache.MadisoncachedClient.Instance.Get<UserInfo>(key);
        //    if (user != null)
        //    {
        //        Madison.Cache.MadisoncachedClient.Instance.Remove(key);
        //    }
        //    return true;
        //}

        //public bool CheckIsSSO()
        //{
        //    bool IsSSO = false;
        //    string key = CacheConfig.GetCacheKey(CacheConfig.AccountLoginLimit, CacheConfig.AccountLoginTypeManagement,CurrentUserId);
        //    string IP = Madison.Cache.MadisoncachedClient.Instance.Get<string>(key);
        //    string currentIP = Common.Common.IPAddress;

        //    log.DebugFormat("LoginFilter curentIP:{0},cacheIP:{1}", currentIP, IP);
        //    if (!string.IsNullOrEmpty(IP) && !string.IsNullOrEmpty(currentIP))
        //    {
        //        if (!IP.Equals(currentIP))
        //        {
        //            RemoveOnlineUserAuth(Cu)
        //        }
        //    }
        //}

        //private SocketResponse CheckActionPermission(string username, string userId, string url)
        //{
        //    bool isLoginOldWay = Common.Common.ShouldLoginInOldWay(username);
        //    SocketResponse hasPermission;
        //    if (isLoginOldWay)
        //    {
        //        hasPermission = PermissionClient.GetPermissionForCurrentUser(int.Parse(userId), url);
        //    }
        //    else
        //    {
        //        hasPermission = PermissionClient.GetPassportPermissionForCurrentUserAsync(int.Parse(userId), url).WaitResult();
        //    }

        //    return hasPermission;
        //}
    }

}

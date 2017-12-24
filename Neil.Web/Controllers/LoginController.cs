using Neil.Commom;
using Neil.Commom.ConfigKey;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Neil.Web.Controllers
{
    public class LoginController : BaseController
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger("LoginController");
        IBLL.IUserInfoService userInfoService { get; set; }
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult GetValidateCode()
        {
            //生成验证码
            Neil.Commom.ValidateCode validateCode = new Neil.Commom.ValidateCode();
            string code = validateCode.CreateRandomAndAharacterCode(4);
            Session["ValidateCode"] = code;
            byte[] bytes = validateCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }

        /// <summary>
        /// 用户登录 https://www.cnblogs.com/iampkm/p/4699788.html ASP.NET MVC Cookie 身份验证 身份验证 后期写这个
        /// </summary>
        /// <returns></returns>
        public ActionResult ValidateLogin(string code, string userName, string password)
        {
            ResultData result = new ResultData();
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    result.message = "验证码为空";
                    return Json(result);
                }

                if (string.IsNullOrWhiteSpace(userName))
                {
                    result.message = "用户名为空";
                    return Json(result);
                }

                if (string.IsNullOrWhiteSpace(password))
                {
                    result.message = "密码为空";
                    return Json(result);
                }

                string validateCode = Session["ValidateCode"] == null ? string.Empty : Session["ValidateCode"] + "";

                if (!string.Equals(code.Trim(), validateCode, StringComparison.InvariantCultureIgnoreCase))
                {
                    result.message = "验证码错误";
                    return Json(result, JsonRequestBehavior.AllowGet);
                }

                var getUserInfo = userInfoService.LoadEntities(t => t.UName == userName && t.UPwd == password).FirstOrDefault();
                if (getUserInfo != null && getUserInfo.UName == userName)
                {
                    String sesionid = Guid.NewGuid() + "";
                    RedisHelper.SetStringTime(sesionid, Commom.JsonHelper.ObjectToJson(getUserInfo), DateTime.Today.AddDays(30));
                    Response.Cookies[CookieKey.neilCookie].Value = sesionid;
                    Response.Cookies[CookieKey.neilCookie].Expires = DateTime.Today.AddDays(30);
                    result.issuccess = true;
                    result.message = "登录成功";
                    /*
                     * 
                     *  HttpCookie nc = new HttpCookie("newcookie");
                nc.Values["name"] = "天轰穿";
                //nc.Values["name"] = HttpUtility.UrlEncode ("天轰穿");
                nc.Values["age"] = "27";
                nc.Values["dt"] = DateTime.Now.ToString();
                Response.Cookies.Add(nc);
                     * //读取Cookie
                HttpCookie getcook = Request.Cookies["newcookie"];
                //Response.Write(HttpUtility.UrlDecode(getcook.Values["name"]));
                Response.Write((getcook.Values["name"]));
                Response.Write("<br>"+getcook.Values["age"]);
                Response.Write("<br>"+getcook.Values["dt"]);
                     * 
                     * 注意乱码
                     * */
                }
                else
                {
                    result.message = "登录失败";
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("报错-->ex:{0}", ex);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}

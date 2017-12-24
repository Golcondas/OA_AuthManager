using Neil.Commom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Neil.Web.Controllers
{
    public class LoginController : Controller
    {
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
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        public ActionResult ValidateLogin(string code, string userName, string password)
        {
            ResultData result = new ResultData();

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
            
            if (!string.Equals(code.Trim(),validateCode, StringComparison.InvariantCultureIgnoreCase))
            {
                result.message = "验证码错误";
                return Json(result);
            }

            var getUserInfo = userInfoService.LoadEntities(t => t.UName == userName && t.UPwd == password).FirstOrDefault();
            if (getUserInfo != null && getUserInfo.UName == userName)
            {
                String ssesionid = Guid.NewGuid() + "";
                RedisHelper.SetStringTime(ssesionid, Commom.JsonHelper.ObjectToJson(getUserInfo), DateTime.Today.AddDays(30));
                Response.Cookies["neilCookie"].Value = ssesionid;
                result.issuccess = true;
                result.message = "登录成功";
            }
            else 
            {
                result.message = "登录失败";
            }
            return Json(result);
        }

    }
}

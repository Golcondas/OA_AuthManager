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
        //IBLL.IUserInfoService userInfoService { get; set; }
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
        public ActionResult Login(string code)
        {
            ResultData result = new ResultData();

            string validateCode = Session["ValidateCode"] == null ? string.Empty : Session["ValidateCode"] + "";
            if (string.IsNullOrWhiteSpace(validateCode))
            {
                result.message = "验证码为空";
                return Json(result.isSuccess);
            }

            if (string.Equals(code.Trim(),validateCode, StringComparison.InvariantCultureIgnoreCase))
            {
                result.isSuccess = true;
                result.message = "登录成功";
            }
            else
            {
                result.isSuccess = false;
                result.message = "登录失败!";
            }
            return Json(result);
        }

    }
}

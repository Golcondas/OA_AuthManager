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

        public ActionResult Login()
        {
            ResultData rd=new ResultData();
            rd.result = false;
            rd.message = "登录成功";
            string validateCode = Session["ValidateCode"] == null ? string.Empty : Session["ValidateCode"] + "";
            if (string.IsNullOrWhiteSpace(validateCode)) {
                rd.message = "验证码错误";
                return Json(rd);
            }

            if()
            return Json(rd.result);
        }

    }
}

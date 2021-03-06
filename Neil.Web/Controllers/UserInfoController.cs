﻿using Neil.Commom;
using Neil.IBLL;
using Neil.Model;
using Neil.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Neil.Web.Controllers
{
    public class UserInfoController : Controller
    {
        //IUserInfoService userInfoService = new Neil.BLL.UserInfoSerivce();
        IUserInfoService userInfoService {get;set;}
        //
        // GET: /UserInfo/
        public ActionResult Index()
        {
            //
            //var userInfoList = userInfo.LoadEntities(t => true);
            //ViewData.Model = userInfoList;
            return View();
        }

        public ActionResult GetUserInfo()
        {
            try
            {
                int pageIndex = int.Parse(Request.Form["page"]);
                int pageSize = int.Parse(Request.Form["rows"]);
                string name = Request.Form["name"];
                string remark = Request.Form["remark"];
                if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(remark))
                {
                    int totalCount = 0;
                    var userInfo = userInfoService.LoadEntitiesWhere<int>(c => true, c => c.ID, false, out totalCount, pageIndex, pageSize).ToList();
                    var userInfoList = UserInfoModel.GetUserInfoList(userInfo);

                    var temp = from u in userInfoList
                               select new
                               {
                                   ID = u.ID,
                                   Name = u.UName,
                                   UPwd = u.UPwd,
                                   Remark = u.Remark,
                                   SubTime = u.SubTime,
                                   Email = u.Email,
                               };
                    var result = temp.ToList();
                    return Json(new { rows = temp.ToList(), total = totalCount }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Neil.Model.ViewModel.UserInfoModel model = new Model.ViewModel.UserInfoModel();
                    model.pageIndex = pageIndex;
                    model.pageSize = pageSize;
                    model.UName = name;
                    model.Remark = remark;
                    int totalCount = 0;
                    var userInfo = userInfoService.LoadEntitiesWhere<int>(c => c.UName.Contains(model.UName) && c.Remark.Contains(model.Remark), c => c.ID, false, out totalCount, pageIndex, pageSize);
                    var userInfoList = UserInfoModel.GetUserInfoList(userInfo.ToList());

                    var temp = from u in userInfoList
                               select new
                               {
                                   ID = u.ID,
                                   Name = u.UName,
                                   UPwd = u.UPwd,
                                   Remark = u.Remark,
                                   SubTime = u.SubTime,
                               };
                    var result = temp.ToList();
                    return Json(new { rows = temp.ToList(), total = totalCount }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                var error=500;

                return Json(error, JsonRequestBehavior.AllowGet);
            }
            
            
        }

        public ActionResult DeleteUserInfoById()
        {
            var id = Request.Form["id"];
            string[] idArray = id.Split(new[] {','});
            List<int> idIntList = new List<int>();
            foreach (var item in idArray)
            {
                idIntList.Add(int.Parse(item));
            }
            var result = userInfoService.DeleteEnities(idIntList);
            if (result)
            {
                return Content("ok");
            }
            else 
            {
                return Content("ok");
            }
        }

        public ActionResult AddUserInfo()
        {
            var name = Request.Form["name"];
            var pwd = Request.Form["pwd"];
            var remark=Request.Form["remark"];
            UserInfo model = new UserInfo();
            model.UName = name;
            model.UPwd = pwd;
            model.Remark = remark;
            model.DelFlag = 0;
            model.Sort = 0+"";
            model.SubTime = DateTime.Now;
            model.ModifiedOn = DateTime.Now;
            var result = userInfoService.AddEntities(model);
            if (result) {
                return Content("ok");
            }
            return Content("no");
        }

        public ActionResult UpdateUserInfo()
        {
            var id = Request.Form["id"];
            var name = Request.Form["name"];
            var pwd = Request.Form["pwd"];
            var remark = Request.Form["remark"];
            UserInfo model = new UserInfo();
            model.ID =Convert.ToInt32(id);
            model.UName = name;
            model.UPwd = pwd;
            model.Remark = remark;
            model.DelFlag = 0;
            model.Sort = 0 + "";
            model.ModifiedOn = DateTime.Now;
            var result = userInfoService.UpdateEntities(model, "UName", "UPwd", "Remark", "ModifiedOn");
            if (result)
            {
                return Content("ok");
            }
            return Content("no");
        }

        public JsonResult GetAdminInfoList() {
            ResultData data = new ResultData();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}

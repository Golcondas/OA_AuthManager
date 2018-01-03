using Neil.Commom;
using Neil.IBLL;
using Neil.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Neil.Web.Controllers
{
    public class RoleController : Controller
    {
        //
        // GET: /Role/

        //public ActionResult Index()
        //{
        //    return View();
        //}
        IRoleService roleService { get; set; }

        public ActionResult GetRoleList(string role) 
        {
            var roleList = roleService.LoadEntities(t=>t.DelFlag!=0).ToList();
            ResultData result = new ResultData();
            result.issuccess=true;
            result.rows = roleList;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddRole(string role)
        {
            ResponseResult responseResult = new ResponseResult();
            Role model = new Role();
            model.RoleName = role;
            model.Modified = DateTime.Now;
            model.Created = DateTime.Now;
            model.DelFlag = 1;
            model.Sort = 0;
            bool result= roleService.AddEntities(model);
            if (result)
            {
                responseResult.issuccess = true;
                responseResult.message = "添加成功";
            }
            else 
            {
                responseResult.message = "添加失败";
            }

            return Json(responseResult, JsonRequestBehavior.AllowGet);
        }
    }
}

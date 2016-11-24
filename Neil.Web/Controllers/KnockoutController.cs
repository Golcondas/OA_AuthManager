﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Neil.Web.Controllers
{
    public class KnockoutController : Controller
    {
        //
        // GET: /Kouckout/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// http://www.cnblogs.com/sccd/p/5971053.html
        /// Knockout学习笔记之一ex1
        /// </summary>
        /// <returns></returns>
        public ActionResult StuKnockoutOne()
        {
            return View();
        }

        /// <summary>
        /// http://www.cnblogs.com/sccd/p/5971053.html
        /// Knockout学习笔记之一ex2
        /// 预定位置
        /// </summary>
        /// <returns></returns>
        public ActionResult SeatReservation()
        {
            return View();
        }
    }
}

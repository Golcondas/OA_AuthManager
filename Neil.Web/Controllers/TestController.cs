using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Neil.Web.Controllers
{
    public class TestController : Controller
    {
        ILog log = log4net.LogManager.GetLogger("Error");
        //
        // GET: /Test/

        public ActionResult Index()
        {
            try
            {
                int a = 3;
                int b = 0;
                int c = a / b;
                return Content("" + c);
            }
            catch (Exception ex)
            {
                log.Error("你妹的：" + ex);
                throw;
            }
            
        }
    }
}

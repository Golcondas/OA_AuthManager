using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Neil.Web.Models
{

    public class MyExceptionAttribute : HandleErrorAttribute
    {
        public static Queue<Exception> exceptionQueue = new Queue<Exception>();
        public override void OnException(ExceptionContext filterContext)
        {
            exceptionQueue.Enqueue(filterContext.Exception);
            string url = "/Error.html";
            filterContext.HttpContext.Response.Redirect(url);
            base.OnException(filterContext);
        }
    }
}
using log4net;
using Neil.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Neil.Web
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();//读取log4Net配置信息
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //开启一个线程
            string logPath = Server.MapPath("/Log/");
            ThreadPool.QueueUserWorkItem((a) =>
            {
                while (true)//不断的扫描日志队列
                {
                    if (MyExceptionAttribute.exceptionQueue.Count() > 0)
                    {
                        Exception ex = MyExceptionAttribute.exceptionQueue.Dequeue();//出对
                        if (ex != null)
                        {
                            //string strName = DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                            //File.AppendAllText(logPath + strName, DateTime.Now.ToString("yyyy-mm-dd hh:mm:ss")+":"+ex + "", Encoding.UTF8);
                            ILog logger = LogManager.GetLogger("Error");
                            logger.ErrorFormat("报错了：{0}",ex+"");
                        }
                        else {
                            Thread.Sleep(3000);
                        }
                    }
                    else {
                        Thread.Sleep(3000);//如何为空就休息一会儿
                    }
                }
            },logPath);
        }
    }
}
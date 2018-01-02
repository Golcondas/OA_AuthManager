

using Neil.IDAL;
using Neil.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Neil.DalAbstratFactory
{
    public partial class DALAbstractFactory
    {
        public static IActionInfoDal CreateActionInfoDal()
        {

            string classFulleName = ConfigurationManager.AppSettings["dalFullName"] + ".ActionInfoDal";

            //object obj = Assembly.Load(ConfigurationManager.AppSettings["assemblyName"]).CreateInstance(classFulleName, true);
            var obj = CreateInstance(classFulleName, ConfigurationManager.AppSettings["assemblyName"]);
            return obj as IActionInfoDal;
        }

        public static IR_User_ActionDal CreateR_User_ActionDal()
        {

            string classFulleName = ConfigurationManager.AppSettings["dalFullName"] + ".R_User_ActionDal";


            //object obj = Assembly.Load(ConfigurationManager.AppSettings["assemblyName"]).CreateInstance(classFulleName, true);
            var obj = CreateInstance(classFulleName, ConfigurationManager.AppSettings["assemblyName"]);


            return obj as IR_User_ActionDal;
        }

        public static IRoleDal CreateRoleDal()
        {

            string classFulleName = ConfigurationManager.AppSettings["dalFullName"] + ".RoleDal";


            //object obj = Assembly.Load(ConfigurationManager.AppSettings["assemblyName"]).CreateInstance(classFulleName, true);
            var obj = CreateInstance(classFulleName, ConfigurationManager.AppSettings["assemblyName"]);


            return obj as IRoleDal;
        }

        public static IUserInfoDal CreateUserInfoDal()
        {

            string classFulleName = ConfigurationManager.AppSettings["dalFullName"] + ".UserInfoDal";


            //object obj = Assembly.Load(ConfigurationManager.AppSettings["assemblyName"]).CreateInstance(classFulleName, true);
            var obj = CreateInstance(classFulleName, ConfigurationManager.AppSettings["assemblyName"]);

            return obj as IUserInfoDal;
        }
    }

}
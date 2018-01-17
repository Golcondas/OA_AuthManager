 

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
		
            string classFulleName = ConfigurationManager.ConnectionStrings["dalFullName"].ConnectionString + ".ActionInfoDal";
            var obj  = CreateInstance(classFulleName,ConfigurationManager.ConnectionStrings["assemblyName"].ConnectionString);
            return obj as IActionInfoDal;
        }
		
	    public static IR_User_ActionDal CreateR_User_ActionDal()
        {
		
            string classFulleName = ConfigurationManager.ConnectionStrings["dalFullName"].ConnectionString + ".R_User_ActionDal";
            var obj  = CreateInstance(classFulleName,ConfigurationManager.ConnectionStrings["assemblyName"].ConnectionString);
            return obj as IR_User_ActionDal;
        }
		
	    public static IRoleDal CreateRoleDal()
        {
		
            string classFulleName = ConfigurationManager.ConnectionStrings["dalFullName"].ConnectionString + ".RoleDal";
            var obj  = CreateInstance(classFulleName,ConfigurationManager.ConnectionStrings["assemblyName"].ConnectionString);
            return obj as IRoleDal;
        }
		
	    public static IUserInfoDal CreateUserInfoDal()
        {
		
            string classFulleName = ConfigurationManager.ConnectionStrings["dalFullName"].ConnectionString + ".UserInfoDal";
            var obj  = CreateInstance(classFulleName,ConfigurationManager.ConnectionStrings["assemblyName"].ConnectionString);
            return obj as IUserInfoDal;
        }
	}
	
}
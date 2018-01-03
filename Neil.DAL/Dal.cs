 
using Neil.DAL;
using Neil.IDAL;
using Neil.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neil.DAL
{
		
	public partial class ActionInfoDal :BaseDal<ActionInfo>,IActionInfoDal
    {

    }
		
	public partial class R_User_ActionDal :BaseDal<R_User_Action>,IR_User_ActionDal
    {

    }
		
	public partial class RoleDal :BaseDal<Role>,IRoleDal
    {

    }
		
	public partial class UserInfoDal :BaseDal<UserInfo>,IUserInfoDal
    {

    }
	
}
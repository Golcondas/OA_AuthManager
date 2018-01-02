 
using Neil.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neil.DalAbstratFactory
{
	public partial interface IDbSession
    {
		IActionInfoDal ActionInfoDal{get;set;}
	
		IR_User_ActionDal R_User_ActionDal{get;set;}
	
		IRoleDal RoleDal{get;set;}
	
		IUserInfoDal UserInfoDal{get;set;}
	}	
}
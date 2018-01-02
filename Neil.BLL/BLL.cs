 
using Neil.IBLL;
using Neil.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Neil.BLL
{
    
    public partial class ActionInfoService :BaseService<ActionInfo>,IActionInfoService
    {
        public override void SetCurrentDal()
        {
            GetCurrentDal = this.DbSession.ActionInfoDal;
        }
    }   
    
    public partial class R_User_ActionService :BaseService<R_User_Action>,IR_User_ActionService
    {
        public override void SetCurrentDal()
        {
            GetCurrentDal = this.DbSession.R_User_ActionDal;
        }
    }   
    
    public partial class RoleService :BaseService<Role>,IRoleService
    {
        public override void SetCurrentDal()
        {
            GetCurrentDal = this.DbSession.RoleDal;
        }
    }

    //public partial class UserInfoSerivce : BaseService<UserInfo>, IUserInfoService
    //{
    //    public override void SetCurrentDal()
    //    {
    //        GetCurrentDal = this.DbSession.UserInfoDal;
    //    }
    //}   
    
}
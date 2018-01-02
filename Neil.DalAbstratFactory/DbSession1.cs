
using Neil.IDAL;
using Neil.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neil.DalAbstratFactory
{
    public partial class DbSession : IDbSession
    {
	
        private IActionInfoDal _ActionInfoDal;
        public IActionInfoDal ActionInfoDal
        {
            get
            {
                if(_ActionInfoDal == null)
                {
                    _ActionInfoDal = DALAbstractFactory.CreateActionInfoDal();
                }
                return _ActionInfoDal;
            }
            set { _ActionInfoDal = value; }
        }
	
        private IR_User_ActionDal _R_User_ActionDal;
        public IR_User_ActionDal R_User_ActionDal
        {
            get
            {
                if(_R_User_ActionDal == null)
                {
                    _R_User_ActionDal = DALAbstractFactory.CreateR_User_ActionDal();
                }
                return _R_User_ActionDal;
            }
            set { _R_User_ActionDal = value; }
        }
	
        private IRoleDal _RoleDal;
        public IRoleDal RoleDal
        {
            get
            {
                if(_RoleDal == null)
                {
                    _RoleDal = DALAbstractFactory.CreateRoleDal();
                }
                return _RoleDal;
            }
            set { _RoleDal = value; }
        }
	
        private IUserInfoDal _UserInfoDal;
        public IUserInfoDal UserInfoDal
        {
            get
            {
                if(_UserInfoDal == null)
                {
                    _UserInfoDal = DALAbstractFactory.CreateUserInfoDal();
                }
                return _UserInfoDal;
            }
            set { _UserInfoDal = value; }
        }
    }	
}
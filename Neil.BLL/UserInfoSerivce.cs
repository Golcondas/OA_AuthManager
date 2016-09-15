using Neil.IBLL;
using Neil.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neil.BLL
{
    public class UserInfoSerivce : BaseService<UserInfo>, IUserInfoService
    {
        public override void SetCurrentDal()
        {
            GetCurrentDal = this.DbSession.GetUserDal;
        }

        public bool DeleteEnities(List<int> list)
        {
            var userInfo = this.DbSession.GetUserDal.LoadEntities(u => list.Contains(u.ID));
            foreach (var item in userInfo)
            {
                this.DbSession.GetUserDal.DeleteByModel(item);
            }
            return this.DbSession.SaveChangesDbSession();
        }
    }
}

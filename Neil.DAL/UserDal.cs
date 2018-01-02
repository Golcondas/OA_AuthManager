
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
    public class UserDal : BaseDal<UserInfo>, IUserDal
    {
        IQueryable<UserInfo> IBaseDal<UserInfo>.GetAllEntity(System.Linq.Expressions.Expression<Func<UserInfo, bool>> condition, int pageIndex, int pageSize, out long total, params Model.OrderModel.OrderModelField[] orderByExpression)
        {
            throw new NotImplementedException();
        }

    }
}

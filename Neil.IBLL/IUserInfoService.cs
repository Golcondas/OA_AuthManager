using Neil.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neil.IBLL
{
    public partial interface IUserInfoService : IBaseService<UserInfo>
    {
        bool DeleteEnities(List<int> list);

        void FindUserPwd(UserInfo userInfo);
    }
}

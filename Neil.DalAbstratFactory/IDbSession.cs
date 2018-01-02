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
        IUserDal GetUserDal { get; set; }
        bool SaveChangesDbSession();
    }
}

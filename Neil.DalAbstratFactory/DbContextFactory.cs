using Neil.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Neil.DalAbstratFactory
{
    public class DbContextFactory
    {
        /// <summary>
        /// 保证线程唯一
        /// </summary>
        /// <returns></returns>
        public static DbContext CreateDbContext()
        {
            DbContext dbContexts = (DbContext)CallContext.GetData("ObjectContext");
            if (dbContexts == null)
            {
                dbContexts = new OAEntities();
                CallContext.SetData("ObjectContext", dbContexts);
            }
            return dbContexts;
        }

    }
}

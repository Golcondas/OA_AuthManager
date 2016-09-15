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
    public class DbSession : IDbSession
    {
        public IUserDal _UserDal;
        public IUserDal GetUserDal 
        {
            get
            {
                if (_UserDal == null)
                {
                    _UserDal = DALAbstractFactory.CreatNewDal();
                }
                return _UserDal;
            }
            set
            {
                _UserDal = value;
            }
        }

        DbContext db = DbContextFactory.CreateDbContext();
        public bool SaveChangesDbSession()
        {
            return db.SaveChanges()>0;
        }
    }
}

using Neil.DalAbstratFactory;
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
    public class BasaDal<T> where T:class,new()
    {
        DbContext db = DbContextFactory.CreateDbContext();
        
        //查找
        public IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> lambdaWehre)
        {
            return db.Set<T>().Where<T>(lambdaWehre);
        }

        //按条件查找排序分页
        public IQueryable<T> LoadEntitiesWhere<S>(
            System.Linq.Expressions.Expression<Func<T, bool>> lambdaWhere,
            System.Linq.Expressions.Expression<Func<T, S>> orderByWhere, bool isAsc, out int totalCount, int pageIndex, int pageSize)
        {
            var temp = db.Set<T>().Where(lambdaWhere);
            totalCount = temp.Count();
            if (isAsc)
            {
                temp = temp.OrderBy<T, S>(orderByWhere).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                temp = temp.OrderByDescending<T, S>(orderByWhere).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            return temp;
        }

        //添加
        public bool AddEntities(T model)
        {
            db.Set<T>().Add(model);
            //return db.SaveChanges() > 0;
            return true;
        }

        //更新
        public bool UpdateEntities(T model, params string[] proNames)
        {
            DbEntityEntry entry = db.Entry<T>(model);
            entry.State = EntityState.Unchanged;
            foreach (string proName in proNames)
            {
                entry.Property(proName).IsModified = true;
            }
            //return db.SaveChanges() > 0;
            return true;
        }

        //删除
        public bool DeleteByModel(T model)
        {
            db.Set<T>().Attach(model);
            db.Set<T>().Remove(model);
            //return db.SaveChanges() > 0;
            return true;
        }
    }
}

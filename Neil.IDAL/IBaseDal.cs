using Neil.Model.OrderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Neil.IDAL
{
    public interface IBaseDal<T> where T:class,new()
    {
        //查找
        IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> lambdaWehre);

        //按条件查找排序分页
        IQueryable<T> LoadEntitiesWhere<S>(
            System.Linq.Expressions.Expression<Func<T, bool>> lambdaWhere,
            System.Linq.Expressions.Expression<Func<T, S>> orderByWhere, bool isAsc, out int totalCount, int pageIndex, int pageSize);

        /// <summary>
        /// https://www.cnblogs.com/yannis/p/3584818.html 动态组合多排序字段 BLL
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <param name="orderByExpression"></param>
        /// <returns></returns>
        IQueryable<T> GetAllEntity(Expression<Func<T, bool>> condition, int pageIndex, int pageSize, out long total, params OrderModelField[] orderByExpression);

        //添加
        bool AddEntities(T model);

        //更新
        bool UpdateEntities(T model, params string[] proNames);

        //删除
        bool DeleteByModel(T model);
    }
}

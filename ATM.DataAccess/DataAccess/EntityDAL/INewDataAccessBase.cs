using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityDAL
{
    public interface INewDataAccessBase<T>
    {
        T GetByCondition(Expression<Func<T, bool>> expression);
        T Add(T entity);
        T Update(T entity);
        void Delete(object id);// truyền string hoặc int
        IEnumerable<T> GetByWhere(Expression<Func<T, bool>> expression);

    }
}

using DataAccess.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityDAL
{
    public class DataAccess<T> : IDataAccess<T> where T : class
    {
        private readonly AtmDataContext _dbConext;
        public DataAccess()
        {
            _dbConext = new AtmDataContext();
        }
        public T Add(T entity)
        {
            var result = _dbConext.Set<T>().Add(entity);
            _dbConext.SaveChanges();
            return result;
        }

        public void Delete(object id)
        {
            var exits = _dbConext.Set<T>().Find(id);
            if (exits != null)
            {
                _dbConext.Set<T>().Remove(exits);
                _dbConext.SaveChanges();
            }
        }

        public T GetByCondition(Expression<Func<T, bool>> expression)
        {
            return _dbConext.Set<T>().FirstOrDefault(expression);

        }

        public T GetById(object id)
        {
            return _dbConext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetByWhere(Expression<Func<T, bool>> expression)
        {
            return _dbConext.Set<T>().Where(expression);
        }

        public T Update(T entity)
        {
            var result = _dbConext.Set<T>().Attach(entity);
            _dbConext.Entry(entity).State = System.Data.Entity.EntityState.Modified; //xem lại
            _dbConext.SaveChanges();
            return result;
        }

    }
}

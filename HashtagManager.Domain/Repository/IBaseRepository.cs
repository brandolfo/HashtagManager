using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HashtagManager.Domain.Repository
{
    public interface IBaseRepository<T> where T: class
    {
        T Add(T entity);
        IQueryable<T> GetAll();
        IEnumerable<T> GetQuery(Expression<Func<bool, T>> expression);
        void Delete(Guid entity);
        T Update(T entity);
        void Save();
    }
}

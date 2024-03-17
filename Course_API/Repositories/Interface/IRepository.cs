using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Course_API.Repositories.Interface
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        T GetByCondition(Expression<Func<T, bool>> expression);
    }
}

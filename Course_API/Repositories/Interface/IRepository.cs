﻿using System.Linq.Expressions;

namespace Course_API.Repositories.Interface
{
    public interface IRepository<T> where T : class
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetByCondition(Expression<Func<T, bool>> expression);
        Task<T> GetById(int id);
    }
}

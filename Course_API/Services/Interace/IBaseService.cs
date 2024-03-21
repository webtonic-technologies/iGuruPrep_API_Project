using System.Linq.Expressions;

namespace Course_API.Services.Interace
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<TEntity> Get(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(int id, TEntity entity);
        Task<TEntity> Delete(int id);
    }
}

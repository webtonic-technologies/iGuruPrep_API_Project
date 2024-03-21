using Course_API.Repositories.Interface;
using Course_API.Services.Interace;
using System.Linq.Expressions;

public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository<TEntity> _repository;

    public BaseService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _repository = _unitOfWork.GetRepository<TEntity>();
    }

    public async Task<TEntity> Get(int id)
    {
        return await _repository.GetById(id);
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression)
    {
        return await _repository.GetByCondition(expression);
    }

    public async Task<TEntity> Add(TEntity entity)
    {
        await _repository.Add(entity);
        _unitOfWork.Save();
        return entity;
    }

    public async Task<TEntity> Update(int id, TEntity entity)
    {
        var existingEntity = await _repository.GetById(id);
        if (existingEntity == null)
            throw new Exception("Entity not found");
        _unitOfWork.Detach(existingEntity);
        await _repository.Update(entity);
        _unitOfWork.Save();
        return entity;
    }

    public async Task<TEntity> Delete(int id)
    {
        var entity = await _repository.GetById(id);
        if (entity == null)
            throw new Exception("Entity not found");
        await _repository.Delete(entity);
        _unitOfWork.Save();
        return entity;
    }
}
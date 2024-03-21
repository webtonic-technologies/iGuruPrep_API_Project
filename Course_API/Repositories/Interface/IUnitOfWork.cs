namespace Course_API.Repositories.Interface
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : class;
        void Save();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        void Detach<T>(T entity) where T : class;
    }
}


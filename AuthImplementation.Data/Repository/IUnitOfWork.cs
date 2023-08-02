namespace AuthImplementation.Data.Repository;

public interface IUnitOfWork<TContext> : IDisposable
{
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

    int SaveChanges();

    Task<int> SaveChangesAsync();
}

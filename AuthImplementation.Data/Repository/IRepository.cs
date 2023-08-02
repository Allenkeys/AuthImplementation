using System.Linq.Expressions;

namespace AuthImplementation.Data.Repository;

public interface IRepository<T>
{
    IQueryable<T> GetAll(bool trackChanges);
    T Create(T entity);
    IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, bool trackChanges);
}

﻿namespace AuthImplementation.Data.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll(bool trackChanges);
        T Create(T entity);
    }
}

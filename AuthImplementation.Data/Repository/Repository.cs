﻿using Microsoft.EntityFrameworkCore;

namespace AuthImplementation.Data.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DbContext _dbContext;
    public Repository(DbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public T Create(T entity)
    {
        _dbContext.Set<T>().Add(entity);
        return entity;
    }

    public IQueryable<T> GetAll(bool trackChanges)
    {
        return trackChanges ? _dbContext.Set<T>() : _dbContext.Set<T>().AsNoTracking();
    }
}

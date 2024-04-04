using Domain;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MDB2Repository;

public class GenericRepository2<T> : IGenericRepository2<T> where T : class, ISeqNo
{
    private IUnitOfWork2 UnitOfWork2 { get; }

    private readonly DbSet<T> _dbSet;

    public GenericRepository2(IUnitOfWork2  unitOfWork2)
    {
        UnitOfWork2 = unitOfWork2;

        _dbSet = UnitOfWork2.MDB2Context.Set<T>();
    }

    public T Add(T entity)
    {
        var entityEntry = _dbSet.Add(entity);
        return entityEntry.Entity;
    }

    public async Task<T> AddAsync(T entity)
    {
        var entityEntry = await _dbSet.AddAsync(entity);
        return entityEntry.Entity;
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.AnyAsync(expression);
    }

    public IQueryable<T> GetAll()
    {
        return _dbSet.AsQueryable();
    }

    public void AttachRemove(T entity)
    {
        var entityEntry = _dbSet.Attach(entity);
        entityEntry.State = EntityState.Deleted;
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
        UnitOfWork2.MDB2Context.Entry(entity).Property(x => x.SeqNo).IsModified = false;
    }

    public void UpdateRange(IEnumerable<T> entities)
    {
        _dbSet.UpdateRange(entities);
        //還沒測試
        foreach (var entity in entities)
        {
            UnitOfWork2.MDB2Context.Entry(entity).Property(x => x.SeqNo).IsModified = false;
        }

    }

    public IQueryable<T> Where(Expression<Func<T, bool>> expression)
    {
        return _dbSet.Where(expression);
    }

    public EntityEntry<T> Attach(T entity)
    {
        return _dbSet.Attach(entity);
    }

    public async Task SaveAsync()
    {
        await UnitOfWork2.SaveAsync();
    }
}
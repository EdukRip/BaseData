using System.Collections.Generic;
using System.Linq;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Shop.Dal.Repositories.Database;

public abstract class BaseDbRepository<T> : BaseRepository<T>
    where T : class, IPrimary
{
    protected readonly ShopEntityContext Context;

    protected BaseDbRepository(ShopEntityContext context)
    {
        Context = context;
    }

    protected abstract DbSet<T> Set { get; }

    protected override IEnumerable<T> GetAll() => Set.ToList();
    protected override T? GetById(int id) => Set.FirstOrDefault(e => e.Id == id);

    protected override T Add(T entity)
    {
        Set.Add(entity);
        Context.SaveChanges();
        return entity;
    }

    protected override bool UpdateEntity(T entity)
    {
        var existing = Set.FirstOrDefault(e => e.Id == entity.Id);
        if (existing is null) return false;
        Set.Update(entity);
        Context.SaveChanges();
        return true;
    }

    protected override bool RemoveEntity(int id)
    {
        var existing = Set.FirstOrDefault(e => e.Id == id);
        if (existing is null) return false;
        Set.Remove(existing);
        Context.SaveChanges();
        return true;
    }
}
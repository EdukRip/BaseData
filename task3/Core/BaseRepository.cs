using System.Collections.Generic;
using System.Linq;

namespace Core;

public abstract class BaseRepository<T> : IRepository<T>
    where T : class, IPrimary
{
    protected abstract IEnumerable<T> GetAll();
    protected abstract T? GetById(int id);
    protected abstract T Add(T entity);
    protected abstract bool UpdateEntity(T entity);
    protected abstract bool RemoveEntity(int id);

    public virtual T Create(T entity)
    {
        if (entity.Id == 0)
        {
            var newId = GetAll().Select(e => e.Id).DefaultIfEmpty(0).Max() + 1;
            entity.AssignId(newId);
        }
        return Add(entity);
    }

    public virtual T? Read(int id) => GetById(id);
    public virtual IEnumerable<T> ReadAll() => GetAll();
    public virtual bool Update(T entity) => UpdateEntity(entity);
    public virtual bool Delete(int id) => RemoveEntity(id);
}
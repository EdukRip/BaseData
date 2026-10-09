using System.Runtime.Serialization;
using Core;

namespace Shop.Dal.Repositories.Xml;

using File = System.IO.File;

public abstract class BaseXmlRepository<T> : IRepository<T>
    where T : class, IPrimary
{
    protected readonly string FilePath;
    private readonly DataContractSerializer _serializer;

    protected BaseXmlRepository(string filePath)
    {
        FilePath = filePath;
        _serializer = new DataContractSerializer(typeof(List<T>));

        var dir = Path.GetDirectoryName(filePath);
        if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
            Directory.CreateDirectory(dir);
        if (!File.Exists(filePath))
            Save(new List<T>());
    }

    // CRUD

    private List<T> Load()
    {
        using var stream = File.OpenRead(FilePath);
        if (stream.Length == 0) return new List<T>();
        return (List<T>?)_serializer.ReadObject(stream) ?? new List<T>();
    }

    private void Save(List<T> items)
    {
        using var stream = File.Create(FilePath);
        _serializer.WriteObject(stream, items);
    }

    public T Create(T entity)
    {
        var items = Load();
        if (entity.Id == 0)
            entity.AssignId(items.Select(e => e.Id).DefaultIfEmpty(0).Max() + 1);
        items.Add(entity);
        Save(items);
        return entity;
    }

    public T? Read(int id)
    {
       return Load().FirstOrDefault(e => e.Id == id);
    }

    public IEnumerable<T> ReadAll() => Load();

    public bool Update(T entity)
    {
        var items = Load();
        var index = items.FindIndex(e => e.Id == entity.Id);
        if (index < 0) return false;
        items[index] = entity;
        Save(items);
        return true;
    }

    public bool Delete(int id)
    {
        var items = Load();
        var removed = items.RemoveAll(e => e.Id == id);
        if (removed == 0) return false;
        Save(items);
        return true;
    }
}
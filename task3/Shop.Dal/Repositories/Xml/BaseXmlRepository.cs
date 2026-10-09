using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using Core;

namespace Shop.Dal.Repositories.Xml;

using File = System.IO.File;
public abstract class BaseXmlRepository<T> : BaseRepository<T>
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

    protected override IEnumerable<T> GetAll() => Load();

    protected override T? GetById(int id) =>
        Load().FirstOrDefault(e => e.Id == id);

    protected override T Add(T entity)
    {
        var items = Load();
        items.Add(entity);
        Save(items);
        return entity;
    }

    protected override bool UpdateEntity(T entity)
    {
        var items = Load();
        var index = items.FindIndex(e => e.Id == entity.Id);
        if (index < 0) return false;
        items[index] = entity;
        Save(items);
        return true;
    }

    protected override bool RemoveEntity(int id)
    {
        var items = Load();
        var removed = items.RemoveAll(e => e.Id == id);
        if (removed == 0) return false;
        Save(items);
        return true;
    }

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
}
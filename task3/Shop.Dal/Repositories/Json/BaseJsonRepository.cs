using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Core;


namespace Shop.Dal.Repositories.Json;

using File = System.IO.File;

public abstract class BaseJsonRepository<T> : BaseRepository<T>
    where T : class, IPrimary
{
    protected readonly string FilePath;
    private readonly JsonSerializerOptions _options = new() { WriteIndented = true };

    protected BaseJsonRepository(string filePath)
    {
        FilePath = filePath;

        var dir = Path.GetDirectoryName(filePath);
        if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
            Directory.CreateDirectory(dir);
        if (!File.Exists(filePath))
            File.WriteAllText(filePath, "[]");
    }

    // --- низкоуровневые операции (специфика JSON) ---

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

    // --- сериализация JSON ---

    private List<T> Load()
    {
        var json = File.ReadAllText(FilePath);
        if (string.IsNullOrWhiteSpace(json)) return new List<T>();
        return JsonSerializer.Deserialize<List<T>>(json, _options) ?? new List<T>();
    }

    private void Save(List<T> items) =>
        File.WriteAllText(FilePath, JsonSerializer.Serialize(items, _options));
}
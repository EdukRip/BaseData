using System.Text.Json;
using Core;

namespace Shop.Dal.Repositories.Json;

using File = System.IO.File;

public abstract class BaseJsonRepository<T> : IRepository<T> where T : class, IPrimary
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

    // --- общая реализация CRUD ---

    private List<T> Load()
    {
        var json = File.ReadAllText(FilePath);
        if (string.IsNullOrWhiteSpace(json)) return new List<T>();
        return JsonSerializer.Deserialize<List<T>>(json, _options) ?? new List<T>();
    }

    private void Save(List<T> items) =>
        File.WriteAllText(FilePath, JsonSerializer.Serialize(items, _options));

    public T Create(T entity)
    {
        var items = Load();
        if (entity.Id == 0)
            entity.AssignId(items.Select(e => e.Id).DefaultIfEmpty(0).Max() + 1);
        items.Add(entity);
        Save(items);
        return entity;
    }

    public T? Read(int id) =>
        Load().FirstOrDefault(e => e.Id == id);

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
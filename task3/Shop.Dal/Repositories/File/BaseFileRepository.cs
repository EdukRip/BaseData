using Core;

namespace Shop.Dal.Repositories.File;

using System.IO;
using File = System.IO.File;

public abstract class BaseFileRepository<T> : IRepository<T> where T : class
{
    protected readonly string FilePath;

    protected BaseFileRepository(string filePath)
    {
        FilePath = filePath;
        var dir = Path.GetDirectoryName(filePath);
        if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
            Directory.CreateDirectory(dir);
        if (!File.Exists(filePath))
            File.WriteAllText(filePath, string.Empty);
    }

    protected abstract string ToLine(T entity);
    protected abstract T FromLine(string line);
    protected abstract int GetId(T entity);
    protected abstract void SetId(T entity, int id);

    // CRUD

    protected List<string> ReadLines()
    {
        List<string> result = new List<string>();
        foreach (var line in File.ReadAllLines(FilePath))
        {
            if (!string.IsNullOrWhiteSpace(line))
                result.Add(line);
        }
        return result;
    }

    protected void WriteLines(List<string> lines)
    {
        File.WriteAllLines(FilePath, lines);
    }

    protected int NextId()
    {
        return ReadAll().Select(GetId).DefaultIfEmpty(0).Max() + 1;
    }

    public T Create(T entity)
    {
        if (GetId(entity) == 0)
            SetId(entity, NextId());

        var lines = ReadLines();
        lines.Add(ToLine(entity));
        WriteLines(lines);
        return entity;
    }

    public T? Read(int id)
    {
        return ReadAll().FirstOrDefault(e => GetId(e) == id);

        // foreach (T element in ReadAll())
        // {
        //     if (GetId(element) == id)
        //         return element;
        // }
        // return default(T);
    }

    public IEnumerable<T> ReadAll()
    {
        return ReadLines().Select(FromLine).ToList();
    }

    public bool Update(T entity)
    {
        var id = GetId(entity);
        var lines = ReadLines();
        var updated = false;

        for (int i = 0; i < lines.Count; i++)
        {
            if (GetId(FromLine(lines[i])) == id)
            {
                lines[i] = ToLine(entity);
                updated = true;
                break;
            }
        }

        if (updated) WriteLines(lines);
        return updated;
    }

    public bool Delete(int id)
    {
        var lines = ReadLines();
        var filtered = new List<string>();
        foreach (var l in lines)
        {
            if (GetId(FromLine(l)) != id)
            {
                filtered.Add(l);
            }
        }

        if (filtered.Count == lines.Count) return false;
        WriteLines(filtered);
        return true;
    }
}

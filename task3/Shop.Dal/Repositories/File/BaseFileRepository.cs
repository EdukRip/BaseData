using System.Collections.Generic;
using System.IO;
using System.Linq;
using Core;


namespace Shop.Dal.Repositories.File;
using File = System.IO.File;
public abstract class BaseFileRepository<T> : BaseRepository<T>
    where T : class, IPrimary
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

    // --- методы, обязательные для наследников ---

    protected abstract string ToLine(T entity);
    protected abstract T FromLine(string line);

    // --- низкоуровневые операции (специфика TXT) ---

    protected override IEnumerable<T> GetAll() =>
        ReadLines().Select(FromLine).ToList();

    protected override T? GetById(int id) =>
        GetAll().FirstOrDefault(e => e.Id == id);

    protected override T Add(T entity)
    {
        var lines = ReadLines();
        lines.Add(ToLine(entity));
        WriteLines(lines);
        return entity;
    }

    protected override bool UpdateEntity(T entity)
    {
        var lines = ReadLines();
        for (int i = 0; i < lines.Count; i++)
        {
            if (FromLine(lines[i]).Id == entity.Id)
            {
                lines[i] = ToLine(entity);
                WriteLines(lines);
                return true;
            }
        }
        return false;
    }

    protected override bool RemoveEntity(int id)
    {
        var lines = ReadLines();
        var filtered = lines.Where(l => FromLine(l).Id != id).ToList();
        if (filtered.Count == lines.Count) return false;
        WriteLines(filtered);
        return true;
    }

    // --- работа с файлом ---

    private List<string> ReadLines()
    {
        var result = new List<string>();
        foreach (var line in File.ReadAllLines(FilePath))
        {
            if (!string.IsNullOrWhiteSpace(line))
                result.Add(line);
        }
        return result;
    }

    private void WriteLines(List<string> lines) =>
        File.WriteAllLines(FilePath, lines);
}
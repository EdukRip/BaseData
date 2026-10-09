namespace Core;
public interface IRepository<T> where T: class
{
    T Create(T entity);
    T? Read(int id);
    IEnumerable<T> ReadAll();
    bool Update(T entity);
    bool Delete(int id);
}
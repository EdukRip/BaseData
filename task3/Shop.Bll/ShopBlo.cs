using Core;

namespace Shop.Bll;

public class ShopBlo : IPrimary
{
    private string _name = string.Empty;
    private string _code = string.Empty;

    public int Id { get; private set; }

    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name не может быть пустым.");
            _name = value;
        }
    }

    public string Code
    {
        get => _code;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Code не может быть пустым.");
            _code = value;
        }
    }

    public ShopBlo(string name, string code)
    {
        Name = name;
        Code = code;
    }

    public ShopBlo(int id, string name, string code)
    {
        Id = id;
        Name = name;
        Code = code;
    }

    public void AssignId(int id) => Id = id;

    public override string ToString()
    {
        return $"{Id}|{Name}|{Code}";
    }
}
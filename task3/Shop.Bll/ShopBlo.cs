using Core;

namespace Shop.Bll;

/// <summary>
/// Бизнес-сущность «магазин».
/// </summary>
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

    // Конструктор для новой сущности
    public ShopBlo(string name, string code)
    {
        Name = name;
        Code = code;
    }

    // Конструктор для восстановления из хранилища
    public ShopBlo(int id, string name, string code)
    {
        Id = id;
        Name = name;
        Code = code;
    }

    // Для IPrimary — нужен, если BLL будет использоваться репозиториями
    public void AssignId(int id) => Id = id;

    public override string ToString() =>
        $"ShopBlo(Id={Id}, Name={Name}, Code={Code})";
}
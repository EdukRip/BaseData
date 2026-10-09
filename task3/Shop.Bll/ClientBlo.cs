using Core;

namespace Shop.Bll;

/// <summary>
/// Бизнес-сущность «клиент».
/// </summary>
public class ClientBlo : IPrimary
{
    private static readonly DateTime DefaultBirthday = new DateTime(1900, 1, 1);

    private string _firstName = string.Empty;
    private string _lastName = string.Empty;
    private string _patronymic = string.Empty;
    private DateTime _birthday = DefaultBirthday;

    public int Id { get; private set; }

    public string FirstName
    {
        get => _firstName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("FirstName не может быть пустым.");
            _firstName = value;
        }
    }

    public string LastName
    {
        get => _lastName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("LastName не может быть пустым.");
            _lastName = value;
        }
    }

    public string Patronymic
    {
        get => _patronymic;
        set => _patronymic = value ?? string.Empty;
    }

    public DateTime Birthday
    {
        get => _birthday;
        set
        {
            if (value == default)
                throw new ArgumentException("Birthday не может быть пустым.");
            _birthday = value;
        }
    }

    public ClientBlo(int id, string firstName, string lastName,
                     string patronymic, DateTime birthday)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
        Birthday = birthday;
    }

    public ClientBlo(string firstName, string lastName,
                     string patronymic, DateTime birthday)
    {
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
        Birthday = birthday;
    }

    public ClientBlo(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public void AssignId(int id) => Id = id;

    public int Age
    {
        get
        {
            var today = DateTime.Today;
            var age = today.Year - Birthday.Year;
            if (Birthday.Date > today.AddYears(-age)) age--;
            return age;
        }
    }

    public override string ToString()
    {
        return $"{Id}|{LastName}|{FirstName}|{Patronymic}|{Birthday:yyyy-MM-dd}";
    }
}
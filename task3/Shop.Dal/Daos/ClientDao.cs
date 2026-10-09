using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Core;

namespace Shop.Dal.Daos;

[DataContract]
public class ClientDao : IPrimary
{
    [Key]
    [DataMember]
    [JsonInclude]
    public int Id {get; private set;}
    [DataMember]
    public string? Name {get; set;}
    [DataMember]
    public string? LastName {get; set;}
    [DataMember]
    public string? Patronymic {get; set;}
    [DataMember]
    public DateTime Birthday {get; set;}

    public void AssignId(int newId) {Id = newId;}

    protected ClientDao() { }
    public ClientDao(string? name, string? lastName, string? patronymic, DateTime birthday)
    {
        Id = 0;
        Name = name;
        LastName = lastName;
        Patronymic = patronymic;
        Birthday = birthday;
    }
    [JsonConstructor]
    public ClientDao(int id, string? name, string? lastName, string? patronymic, DateTime birthday)
    {
        Id = id;
        Name = name;
        LastName = lastName;
        Patronymic = patronymic;
        Birthday = birthday;
    }

    public override string ToString()
    {
        return $"{Id}|{Name}|{LastName}|{Patronymic}|{Birthday}";
    }
}
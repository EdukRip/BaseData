using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Core;

namespace Shop.Dal.Daos;

[DataContract]
public class ClientDao : IPrimary
{
    [DataMember]
    [JsonInclude]
    public int Id {get; private set;}
    [DataMember]
    public string? Name {get; set;}
    [DataMember]
    public string? LastName {get; set;}
    [DataMember]
    public string? MiddleName {get; set;}
    [DataMember]
    public DateTime Birthday {get; set;}

    public void AssignId(int newId) {Id = newId;}


    public ClientDao(string? name, string? lastname, string? middlename, DateTime birthday)
    {
        Id = 0;
        Name = name;
        LastName = lastname;
        MiddleName = middlename;
        Birthday = birthday;
    }
    [JsonConstructor]
    public ClientDao(int id, string? name, string? lastname, string? middlename, DateTime birthday)
    {
        Id = id;
        Name = name;
        LastName = lastname;
        MiddleName = middlename;
        Birthday = birthday;
    }

    public override string ToString()
    {
        return $"{Id}|{Name}|{LastName}|{MiddleName}|{Birthday}";
    }
}
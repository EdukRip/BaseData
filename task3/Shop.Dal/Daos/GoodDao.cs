using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Core;

namespace Shop.Dal.Daos;

[DataContract]
public class GoodDao : IPrimary
{
    [DataMember]
    [JsonInclude]
    public int Id {get; private set;}
    [DataMember] 
    public string? Name {get; set;}
    [DataMember]
    public string? Code {get; set;}

    public void AssignId(int newId) {Id = newId;}

    public GoodDao(string? name, string? code)
    {
        Id = 0;
        Name = name;
        Code = code;
    }
    [JsonConstructor]
    public GoodDao(int id, string? name, string? code)
    {
        Id = id;
        Name = name;
        Code = code;
    }

    public override string ToString()
    {
        return $"{Id}|{Name}|{Code}";
    }
}
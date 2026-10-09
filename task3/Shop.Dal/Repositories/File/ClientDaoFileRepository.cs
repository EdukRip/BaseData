using System.Globalization;
using Shop.Dal.Daos;

namespace Shop.Dal.Repositories.File;

public class ClientDaoFileRepository : BaseFileRepository<ClientDao>
{
    private const string DateFormat = "yyyy-MM-dd";

    public ClientDaoFileRepository(string filePath = "task3/Shop.Dal/Data/clients.txt")
        : base(filePath) { }

    protected override string ToLine(ClientDao e)
    {
        var bd = e.Birthday.ToString(DateFormat) ?? "";
        return $"{e.Id}|{e.Name}|{e.LastName}|{e.Patronymic}|{bd}";
    }

    protected override ClientDao FromLine(string line)
    {
        var p = line.Split('|');
        DateTime bd;
        bd = DateTime.ParseExact(p[4], DateFormat, CultureInfo.InvariantCulture);

        return new ClientDao(int.Parse(p[0]), p[1], p[2], p[3], bd);
    }
}
using Shop.Dal.Daos;

namespace Shop.Dal.Repositories.File;

public class GoodDaoFileRepository : BaseFileRepository<GoodDao>
{
    public GoodDaoFileRepository(string filePath = "task3/Shop.Dal/Data/goods.txt")
        : base(filePath) { }

    protected override string ToLine(GoodDao e) => $"{e.Id}|{e.Name}|{e.Code}";

    protected override GoodDao FromLine(string line)
    {
        var p = line.Split('|');
        return new GoodDao(int.Parse(p[0]), p[1], p[2]);
    }
}
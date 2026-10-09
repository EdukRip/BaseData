using Shop.Dal.Daos;

namespace Shop.Dal.Repositories.File;

public class ShopDaoFileRepository : BaseFileRepository<ShopDao>
{
    public ShopDaoFileRepository(string filePath = "task3/Shop.Dal/Data/shops.txt")
        : base(filePath) { }

    protected override string ToLine(ShopDao e) => $"{e.Id}|{e.Name}|{e.Code}";

    protected override ShopDao FromLine(string line)
    {
        var p = line.Split('|');
        return new ShopDao(int.Parse(p[0]), p[1], p[2]);
    }

    protected override int GetId(ShopDao e) => e.Id;

    protected override void SetId(ShopDao e, int id) => e.AssignId(id);
}
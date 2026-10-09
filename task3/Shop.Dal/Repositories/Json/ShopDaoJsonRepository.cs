using Shop.Dal.Daos;

namespace Shop.Dal.Repositories.Json;

public class ShopDaoJsonRepository : BaseJsonRepository<ShopDao>
{
    public ShopDaoJsonRepository(string filePath = "task3/Shop.Dal/Data/shops.json") : base(filePath) { }
}
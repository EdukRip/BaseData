using Shop.Dal.Daos;

namespace Shop.Dal.Repositories.Json;

public class GoodDaoJsonRepository : BaseJsonRepository<GoodDao>
{
    public GoodDaoJsonRepository(string filePath = "task3/Shop.Dal/Data/goods.json") : base(filePath) { }
}
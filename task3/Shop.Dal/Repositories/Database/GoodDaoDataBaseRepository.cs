using Microsoft.EntityFrameworkCore;
using Shop.Dal.Daos;

namespace Shop.Dal.Repositories.Database;

public class GoodDaoDataBaseRepository : BaseDbRepository<GoodDao>
{
    public GoodDaoDataBaseRepository(ShopEntityContext context)
        : base(context) { }

    protected override DbSet<GoodDao> Set => Context.Goods;
}
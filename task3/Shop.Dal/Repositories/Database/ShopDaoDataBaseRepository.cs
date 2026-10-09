using Microsoft.EntityFrameworkCore;
using Shop.Dal.Daos;

namespace Shop.Dal.Repositories.Database;

public class ShopDaoDataBaseRepository : BaseDbRepository<ShopDao>
{
    public ShopDaoDataBaseRepository(ShopEntityContext context)
        : base(context) { }

    protected override DbSet<ShopDao> Set => Context.Shops;
}
using Microsoft.EntityFrameworkCore;
using Shop.Dal.Daos;

namespace Shop.Dal.Repositories.Database;

public class ClientDaoDataBaseRepository : BaseDbRepository<ClientDao>
{
    public ClientDaoDataBaseRepository(ShopEntityContext context)
        : base(context) { }

    protected override DbSet<ClientDao> Set => Context.Clients;
}
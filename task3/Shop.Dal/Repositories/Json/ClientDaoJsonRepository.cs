using Shop.Dal.Daos;

namespace Shop.Dal.Repositories.Json;

public class ClientDaoJsonRepository : BaseJsonRepository<ClientDao>
{
    public ClientDaoJsonRepository(string filePath = "task3/Shop.Dal/Data/clients.json") : base(filePath) { }
}
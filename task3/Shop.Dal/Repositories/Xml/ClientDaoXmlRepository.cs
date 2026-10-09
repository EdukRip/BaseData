using Shop.Dal.Daos;

namespace Shop.Dal.Repositories.Xml;

public class ClientDaoXmlRepository : BaseXmlRepository<ClientDao>
{
    public ClientDaoXmlRepository(string filePath = "task3/Shop.Dal/Data/clients.xml")
        : base(filePath) { }
}
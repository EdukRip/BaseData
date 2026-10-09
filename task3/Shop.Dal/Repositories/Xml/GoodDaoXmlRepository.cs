using Shop.Dal.Daos;

namespace Shop.Dal.Repositories.Xml;

public class GoodDaoXmlRepository : BaseXmlRepository<GoodDao>
{
    public GoodDaoXmlRepository(string filePath = "task3/Shop.Dal/Data/goods.xml")
        : base(filePath) { }
}
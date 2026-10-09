using Shop.Dal.Daos;

namespace Shop.Dal.Repositories.Xml;

public class ShopDaoXmlRepository : BaseXmlRepository<ShopDao>
{
    public ShopDaoXmlRepository(string filePath = "task3/Shop.Dal/Data/shops.xml")
        : base(filePath) { }
}
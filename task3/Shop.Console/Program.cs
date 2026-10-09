using Shop.Dal;
using Shop.Dal.Daos;
using Shop.Dal.Repositories.Database;
using Shop.Dal.Repositories.File;
using Shop.Dal.Repositories.Json;
using Shop.Dal.Repositories.Xml;

// ДАННЫЕ
{
    var shops = new List<ShopDao>
    {
        new("Пятёрочка",   "SH-001"),
        new("Магнит",      "SH-002"),
        new("Перекрёсток", "SH-003"),
    };

    var clients = new List<ClientDao>
    {
        new("Иван",    "Иванов",    "Иванович",  new DateTime(1990, 5, 20)),
        new("Анна",    "Петрова",   "Сергеевна", new DateTime(1985, 3, 12)),
        new("Олег",    "Сидоров",   "Петрович",  new DateTime(1978, 1, 15)),
        new("Мария",   "Кузнецова", "Андреевна", new DateTime(2000, 7, 8)),
        new("Дмитрий", "Смирнов",   "Олегович",  new DateTime(1995, 11, 30)),
    };

    var goods = new List<GoodDao>
    {
        new("Хлеб Бородинский",   "GD-001"),
        new("Молоко 3.2%",        "GD-002"),
        // ... остальные 28
    };

    // TXT
    var shopTxt = new ShopDaoFileRepository();
    var clientTxt = new ClientDaoFileRepository();
    var goodTxt = new GoodDaoFileRepository();

    foreach (var s in shops) shopTxt.Create(s);
    foreach (var c in clients) clientTxt.Create(c);
    foreach (var g in goods) goodTxt.Create(g);

    Console.WriteLine($"TXT  → магазинов: {shopTxt.ReadAll().Count()}, " +
                      $"клиентов: {clientTxt.ReadAll().Count()}, " +
                      $"товаров: {goodTxt.ReadAll().Count()}");

    // XML
    var shopXml = new ShopDaoXmlRepository();
    var clientXml = new ClientDaoXmlRepository();
    var goodXml = new GoodDaoXmlRepository();

    foreach (var s in shops) shopXml.Create(s);
    foreach (var c in clients) clientXml.Create(c);
    foreach (var g in goods) goodXml.Create(g);

    Console.WriteLine($"XML  → магазинов: {shopXml.ReadAll().Count()}, " +
                      $"клиентов: {clientXml.ReadAll().Count()}, " +
                      $"товаров: {goodXml.ReadAll().Count()}");

    // JSON
    var shopJson = new ShopDaoJsonRepository();
    var clientJson = new ClientDaoJsonRepository();
    var goodJson = new GoodDaoJsonRepository();

    foreach (var s in shops) shopJson.Create(s);
    foreach (var c in clients) clientJson.Create(c);
    foreach (var g in goods) goodJson.Create(g);

    Console.WriteLine($"JSON → магазинов: {shopJson.ReadAll().Count()}, " +
                      $"клиентов: {clientJson.ReadAll().Count()}, " +
                      $"товаров: {goodJson.ReadAll().Count()}");
}

// БАЗА ДАННЫХ

Console.WriteLine("\n=== DATABASE ===");

var context = new ShopEntityContext("task3/Shop.Dal/Data/shop.db");
var shopDb = new ShopDaoDataBaseRepository(context);
var goodDb = new GoodDaoDataBaseRepository(context);
var clientDb = new ClientDaoDataBaseRepository(context);

var shop1 = shopDb.Create(new ShopDao("Пятёрочка", "SH-001"));
var shop2 = shopDb.Create(new ShopDao("Магнит", "SH-002"));
var good1 = goodDb.Create(new GoodDao("Хлеб", "GD-001"));
var client1 = clientDb.Create(new ClientDao("Иван", "Иванов", "Иванович", new DateTime(1990, 5, 20)));
Console.WriteLine($"CREATE: {shop1}, {shop2}, {good1}, {client1}");

Console.WriteLine($"READ: {shopDb.Read(shop1.Id)}");

Console.WriteLine("READALL:");
foreach (var s in shopDb.ReadAll())
{ 
    Console.WriteLine($"  {s}"); 
}

shop1.Name = "Перекрёсток";
shopDb.Update(shop1);
Console.WriteLine($"UPDATE: {shopDb.Read(shop1.Id)}");

shopDb.Delete(shop2.Id);
Console.WriteLine($"DELETE: осталось {shopDb.ReadAll().Count()} магазин");
using Shop.Dal.Daos;
using Shop.Dal.Repositories.File;
using Shop.Dal.Repositories.Json;
using Shop.Dal.Repositories.Xml;

// ============================================================
// ДАННЫЕ
// ============================================================

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
    new("Сыр Российский",     "GD-003"),
    new("Масло сливочное",    "GD-004"),
    new("Кефир 1%",           "GD-005"),
    new("Йогурт натуральный", "GD-006"),
    new("Творог 5%",          "GD-007"),
    new("Сметана 20%",        "GD-008"),
    new("Куриное яйцо С1",    "GD-009"),
    new("Мука пшеничная",     "GD-010"),
    new("Сахар-песок",        "GD-011"),
    new("Соль поваренная",    "GD-012"),
    new("Рис длиннозёрный",   "GD-013"),
    new("Гречка ядрица",      "GD-014"),
    new("Макароны спагетти",  "GD-015"),
    new("Масло оливковое",    "GD-016"),
    new("Чай чёрный",         "GD-017"),
    new("Кофе молотый",       "GD-018"),
    new("Какао-порошок",      "GD-019"),
    new("Печенье овсяное",    "GD-020"),
    new("Шоколад тёмный",     "GD-021"),
    new("Конфеты шоколадные", "GD-022"),
    new("Вода минеральная",   "GD-023"),
    new("Сок яблочный",       "GD-024"),
    new("Сок апельсиновый",   "GD-025"),
    new("Лимонад",            "GD-026"),
    new("Курица охлаждённая", "GD-027"),
    new("Говядина тушёная",   "GD-028"),
    new("Свинина шея",        "GD-029"),
    new("Рыба морская",       "GD-030"),
};

// ============================================================
// TXT (File-репозитории)
// ============================================================

var shopTxt = new ShopDaoFileRepository();
var clientTxt = new ClientDaoFileRepository();
var goodTxt = new GoodDaoFileRepository();

foreach (var s in shops) shopTxt.Create(s);
foreach (var c in clients) clientTxt.Create(c);
foreach (var g in goods) goodTxt.Create(g);

Console.WriteLine($"TXT  → магазинов: {shopTxt.ReadAll().Count()}, " +
                  $"клиентов: {clientTxt.ReadAll().Count()}, " +
                  $"товаров: {goodTxt.ReadAll().Count()}");

// ============================================================
// XML
// ============================================================

var shopXml = new ShopDaoXmlRepository();
var clientXml = new ClientDaoXmlRepository();
var goodXml = new GoodDaoXmlRepository();

foreach (var s in shops) shopXml.Create(s);
foreach (var c in clients) clientXml.Create(c);
foreach (var g in goods) goodXml.Create(g);

Console.WriteLine($"XML  → магазинов: {shopXml.ReadAll().Count()}, " +
                  $"клиентов: {clientXml.ReadAll().Count()}, " +
                  $"товаров: {goodXml.ReadAll().Count()}");

// ============================================================
// JSON
// ============================================================

var shopJson = new ShopDaoJsonRepository();
var clientJson = new ClientDaoJsonRepository();
var goodJson = new GoodDaoJsonRepository();

foreach (var s in shops) shopJson.Create(s);
foreach (var c in clients) clientJson.Create(c);
foreach (var g in goods) goodJson.Create(g);

Console.WriteLine($"JSON → магазинов: {shopJson.ReadAll().Count()}, " +
                  $"клиентов: {clientJson.ReadAll().Count()}, " +
                  $"товаров: {goodJson.ReadAll().Count()}");
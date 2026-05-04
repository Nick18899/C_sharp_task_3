Console.WriteLine("=== Задача 1: Repository<T> ===\n");

var productRepo = new Repository<Product>();
productRepo.Add(new Product(1, "Laptop", 75000));
productRepo.Add(new Product(2, "Phone", 35000));
productRepo.Add(new Product(3, "Headphones", 1200));
productRepo.Add(new Product(4, "Monitor", 25000));

Console.WriteLine($"Всего продуктов: {productRepo.Count}");

var found = productRepo.GetById(2);
Console.WriteLine($"GetById(2): {found}");

var expensive = productRepo.Find(p => p.Price > 10000);
Console.WriteLine("Продукты дороже 10000:");
foreach (var p in expensive)
    Console.WriteLine($"  {p}");

Console.WriteLine("\nПопытка добавить дубликат (Id=1):");
try
{
    productRepo.Add(new Product(1, "Duplicate", 0));
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"  Исключение: {ex.Message}");
}

var userRepo = new Repository<User>();
userRepo.Add(new User(10, "alice"));
userRepo.Add(new User(11, "bob"));
userRepo.Add(new User(12, "charlie"));

Console.WriteLine($"\nВсего пользователей: {userRepo.Count}");
Console.WriteLine($"GetById(11): {userRepo.GetById(11)}");

var removed = userRepo.Remove(12);
Console.WriteLine($"Remove(12): {removed}, Осталось: {userRepo.Count}");

Console.WriteLine("\n=== Задача 2: CollectionUtils ===\n");

var ints = new List<int> { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5 };
var distinctInts = CollectionUtils.Distinct(ints);
Console.WriteLine($"Distinct(int): [{string.Join(", ", distinctInts)}]");

var strings = new List<string> { "apple", "banana", "apple", "cherry", "banana", "date" };
var distinctStrings = CollectionUtils.Distinct(strings);
Console.WriteLine($"Distinct(string): [{string.Join(", ", distinctStrings)}]");

var words = new List<string> { "cat", "dog", "ant", "bear", "fox", "wolf", "bee" };
var grouped = CollectionUtils.GroupBy(words, w => w.Length);
Console.WriteLine("\nGroupBy длине слова:");
foreach (var kvp in grouped)
    Console.WriteLine($"  Длина {kvp.Key}: [{string.Join(", ", kvp.Value)}]");

var dict1 = new Dictionary<string, int> { ["hello"] = 3, ["world"] = 5, ["foo"] = 1 };
var dict2 = new Dictionary<string, int> { ["world"] = 2, ["foo"] = 4, ["bar"] = 7 };
var merged = CollectionUtils.Merge(dict1, dict2, (a, b) => a + b);
Console.WriteLine("\nMerge (сумма при конфликте):");
foreach (var kvp in merged)
    Console.WriteLine($"  {kvp.Key}: {kvp.Value}");

var products = new List<Product>
{
    new Product(1, "Laptop", 75000),
    new Product(2, "Phone", 35000),
    new Product(3, "Headphones", 1200),
    new Product(4, "Monitor", 25000),
};
var mostExpensive = CollectionUtils.MaxBy(products, p => p.Price);
Console.WriteLine($"\nMaxBy цене: {mostExpensive}");

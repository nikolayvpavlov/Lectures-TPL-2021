// See https://aka.ms/new-console-template for more information
using ASomeTalks;

Console.WriteLine("Hello, World!");

var products = new List<Product>()
{
    new Product() { Id = 1, Name = "Laptop "},
    new Product() { Id = 2, Name = "Mouse "},
    new Product() { Id=3, Name = "Keyboard"}
};

int id = 2;

//Redundant use of where.
//var prod = products.Where(c => c.Id == id).FirstOrDefault();
var prod = products.FirstOrDefault(c => c.Id == id);

Dictionary<Product, int> stock = new Dictionary<Product, int>();

bool isOK = (stock.ContainsKey(prod) && stock[prod] > 0);
//if (!isOk) break;

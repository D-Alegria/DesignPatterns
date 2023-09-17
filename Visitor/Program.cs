using Visitor;

Console.Title = "Visitor";

var container = new Container();

container.Customers.Add(new Customer(500, "Sophie"));
container.Customers.Add(new Customer(1000, "Karen"));
container.Customers.Add(new Customer(800, "Sven"));
container.Employees.Add(new Employee(18, "Kevin"));
container.Employees.Add(new Employee(5, "Tom"));

DiscountVisitor discountVisitor = new();
container.Accept(discountVisitor);

Console.WriteLine($"Total discount: {discountVisitor.TotalDiscountGiven}");

Console.ReadKey();
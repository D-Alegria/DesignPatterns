using Facade;

Console.Title = "Facade";

var facade = new DiscountFacade();
Console.WriteLine($"Discount percentage foe customer with id 1: {facade.CalculateDiscount(1)}");
Console.WriteLine($"Discount percentage foe customer with id 10: {facade.CalculateDiscount(10)}");

Console.ReadKey();
using TemplateMethod;

Console.Title = "Template Method";

ExchangeMailParser exchangeMailParser = new();
Console.WriteLine(exchangeMailParser.ParseMailBody(Guid.NewGuid().ToString()));
Console.WriteLine();

ApacheMailParser apacheMailParser = new();
Console.WriteLine(apacheMailParser.ParseMailBody(Guid.NewGuid().ToString()));
Console.WriteLine();

GoogleMailParser googleMailParser = new();
Console.WriteLine(googleMailParser.ParseMailBody(Guid.NewGuid().ToString()));

Console.ReadKey();
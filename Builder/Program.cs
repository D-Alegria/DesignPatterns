using BuilderPattern;

Console.Title = "Builder";

var garage = new Garage();

var miniBuilder = new MiniBuilder();
var bmwBuilder = new BMWBuilder();

garage.Constructor(miniBuilder);
garage.Show();

garage.Constructor(bmwBuilder);
garage.Show();

Console.ReadKey();
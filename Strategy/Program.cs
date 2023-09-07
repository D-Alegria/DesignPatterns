using Strategy;

Console.Title = "Strategy";

var order = new Order("Demilade", "Visual Studio License", 5);
order.ExportService = new CSVExportServce();
order.Export();

order.ExportService = new JSONExportServce();
order.Export();

var orderWithMethodParameter = new OrderWithMethodParameter("Demilade", "Visual Studio License", 5);
orderWithMethodParameter.Export(new CSVExportServce());

orderWithMethodParameter.Export(new JSONExportServce());

Console.ReadKey();
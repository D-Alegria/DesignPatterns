using Decorator;

Console.Title = "Decorator";

// instantiate mail services
var cloudMailService = new CloudMailService();
cloudMailService.SendMail("Hi there, Cloud.");

var onPremiseMailService = new OnPremiseMailService();
onPremiseMailService.SendMail("Hi there, OnPremise");

// Add More Functionality(Behaviours)
var statisticsDecorator = new StatisticsDecorator(cloudMailService);
statisticsDecorator.SendMail($"Hi there via {nameof(StatisticsDecorator)} wrapper");

var messageDatabaseDecorator = new MessageDatabaseDecorator(onPremiseMailService);
messageDatabaseDecorator.SendMail($"Hi there via {nameof(MessageDatabaseDecorator)} wrapper");

Console.ReadKey();
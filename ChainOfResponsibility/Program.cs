using System.ComponentModel.DataAnnotations;
using ChainOfResponsibility;

Console.Title = "Chain of Responsibility";

var validDocument = new Document("How to Avoid Java Development", DateTimeOffset.UtcNow, true, true);
var inValidDocument = new Document("How to Avoid Java Development", DateTimeOffset.UtcNow, false, true);

var documentHandlerChain = new DocumentTitleHandler();
documentHandlerChain
    .SetSuccessor(new DocumentLastModifiedHandler())
    .SetSuccessor(new DocumentApprovedByLitigationHandler())
    .SetSuccessor(new DocumentApprovedByManagementHandler());


try
{
    documentHandlerChain.Handle(validDocument);
    Console.WriteLine("Valid document is valid.");
    documentHandlerChain.Handle(inValidDocument);
    Console.WriteLine("Invalid document is valid.");
}
catch (ValidationException validationException)
{
    Console.WriteLine(validationException.Message);
}

Console.ReadKey();
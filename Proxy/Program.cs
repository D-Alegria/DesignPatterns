Console.Title = "Proxy";

// without proxy
Console.WriteLine("Constructing document.");
var myDocument = new Proxy.Document("MyDoc.dmi");
Console.WriteLine("Document constructed.");
myDocument.DisplayDocument();

Console.WriteLine();

// with proxy
Console.WriteLine("Constructing document proxy.");
var myDocumentProxy = new Proxy.DocumentProxy("MyDoc.dmi");
Console.WriteLine("Document proxy constructed.");
myDocumentProxy.DisplayDocument();

Console.WriteLine();

// with chain proxy
Console.WriteLine("Constructing protected document proxy.");
var myProtectedDocumentProxy = new Proxy.ProtectedDocumentProxy("MyDoc.dmi", "Viewer");
Console.WriteLine("Protected document proxy constructed.");
myProtectedDocumentProxy.DisplayDocument();

Console.WriteLine();

// woth chain proxy, no access
Console.WriteLine("Constructing protected document proxy.");
myProtectedDocumentProxy = new Proxy.ProtectedDocumentProxy("MyDoc.dmi", "Transferer");
Console.WriteLine("Protected document proxy constructed.");
myProtectedDocumentProxy.DisplayDocument();

Console.ReadKey();
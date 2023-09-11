using Mediator;

Console.Title = "Mediator";

TeamChatRoom teamChatRoom = new();

var demi = new AccountManager("Demi");
var temi = new AccountManager("Temi");
var lashe = new AccountManager("Lashe");
var victor = new Lawyer("Victor");
var Dubem = new Lawyer("Dubem");

teamChatRoom.Register(demi);
teamChatRoom.Register(temi);
teamChatRoom.Register(lashe);
teamChatRoom.Register(victor);
teamChatRoom.Register(Dubem);

demi.Send("Hi everyone, who would love to go on a trip to Ibiza next year");
victor.Send("Sure on it");
Dubem.Send("Temi","Can we hop on a call");
Dubem.Send("Demi", "All good to go");
demi.SendTo<AccountManager>("Tickets should be purchased");

Console.ReadKey();
using AbstractFactory;

Console.Title = "Abstract Factory";

var nigeriaShopingCartPurchaseFactory = new NigeriaShoppingCartPurchaseFactory();
var shoppingCartForNigeria = new ShoppingCart(nigeriaShopingCartPurchaseFactory);
shoppingCartForNigeria.CalculateCosts();

var franceShopingCartPurchaseFactory = new FranceShoppingCartPurchaseFactory();
var shoppingCartForFrance = new ShoppingCart(franceShopingCartPurchaseFactory);
shoppingCartForFrance.CalculateCosts();

Console.ReadKey();
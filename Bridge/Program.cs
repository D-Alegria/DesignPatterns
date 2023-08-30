using Bridge;

Console.Title = "Bridge";

var noCoupon = new NoCoupon();
var oneCoupon = new OneCoupon();
var twoCoupon = new TwoCoupon();

var meatBasedMenu = new MeatBasedMenu(noCoupon);
Console.WriteLine($"Meat based menu, no coupon: {meatBasedMenu.CalculatePrice()} euro.");

meatBasedMenu = new MeatBasedMenu(oneCoupon);
Console.WriteLine($"Meat based menu, one coupon: {meatBasedMenu.CalculatePrice()} euro.");

meatBasedMenu = new MeatBasedMenu(twoCoupon);
Console.WriteLine($"Meat based menu, two coupon: {meatBasedMenu.CalculatePrice()} euro.");

var vegetarianMenu = new VegetarianMenu(noCoupon);
Console.WriteLine($"Vegetarian menu, no coupon: {vegetarianMenu.CalculatePrice()} euro.");

vegetarianMenu = new VegetarianMenu(oneCoupon);
Console.WriteLine($"Vegetarian menu, one coupon: {vegetarianMenu.CalculatePrice()} euro.");

vegetarianMenu = new VegetarianMenu(twoCoupon);
Console.WriteLine($"Vegetarian menu, two coupon: {vegetarianMenu.CalculatePrice()} euro.");

Console.ReadKey();
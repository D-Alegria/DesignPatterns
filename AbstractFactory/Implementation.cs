namespace AbstractFactory
{

    /// <summary>
    /// AbstractFactory
    /// </summary>
    public interface IShoppingCartPurchaseFactory
    {
        IDiscountService CreateDiscountService();
        IShippingCostsService CreateShippingCostsService();
    }

    /// <summary>
    /// AbstractProduct
    /// </summary>
    public interface IDiscountService
    {
        int DiscountPercentage { get; }
    }

    /// <summary>
    /// ConcreteProduct
    /// </summary>
    public class NigeriaDiscountService : IDiscountService
    {
        public int DiscountPercentage => 20;
    }

    // <summary>
    /// ConcreteProduct
    /// </summary>
    public class FranceiscountService : IDiscountService
    {
        public int DiscountPercentage => 10;
    }

    /// <summary>
    /// AbstractProduct
    /// </summary>
    public interface IShippingCostsService
    {
        decimal ShippingCosts { get; }
    }

    /// <summary>
    /// ConcreteProduct
    /// </summary>
    public class NigeriaShippingCostService : IShippingCostsService
    {
        public decimal ShippingCosts => 20;
    }

    /// <summary>
    /// ConcreteProduct
    /// </summary>
    public class FranceShippingCostService : IShippingCostsService
    {
        public decimal ShippingCosts => 25;
    }

    /// <summary>
    /// ConcreteFactory
    /// </summary>
    public class NigeriaShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new NigeriaDiscountService();
        }

        public IShippingCostsService CreateShippingCostsService()
        {
            return new NigeriaShippingCostService();
        }
    }

    /// <summary>
    /// ConcreteFactory
    /// </summary>
    public class FranceShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new FranceiscountService();
        }

        public IShippingCostsService CreateShippingCostsService()
        {
            return new FranceShippingCostService();
        }
    }

    /// <summary>
    /// Client
    /// </summary>
    public class ShoppingCart
    {
        private readonly IDiscountService _discountService;
        private readonly IShippingCostsService _shippingCostsService;
        private int _orderCosts;

        public ShoppingCart(IShoppingCartPurchaseFactory factory)
        {
            _discountService = factory.CreateDiscountService();
            _shippingCostsService = factory.CreateShippingCostsService();
            _orderCosts = 200;
        }

        public void CalculateCosts()
        {
            Console.WriteLine($"Total costs = {_orderCosts - (_orderCosts / 100 * _discountService.DiscountPercentage) + _shippingCostsService.ShippingCosts}");
        }

    }
}

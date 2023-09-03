namespace Facade
{
    /// <summary>
    /// Facade
    /// This knows which subsystem classes are responsible for a request, and a
    /// delegates client requests to appropriate subsystem objects.
    /// </summary>
    public class DiscountFacade
    {
        private readonly OrderService _orderService = new();
        private readonly CustomerDiscountBaseService _customerDiscountBaseService = new();
        private readonly DayOfTheWeekFactorService _dayOfTheWeekFactorService = new();

        public double CalculateDiscount(int customerId)
        {
            if (!_orderService.HasEnoughOrders(customerId))
            {
                return 0;
            }

            return _customerDiscountBaseService.CalculateDiscountBase(customerId) * _dayOfTheWeekFactorService.CalculateDayOfTheWeekFactor();
        }
    }

    /// <summary>
    /// Subsystem Class
    /// </summary>
    public class OrderService
    {
        public bool HasEnoughOrders(int customerId)
        {
            return customerId > 5;
        }
    }

    /// <summary>
    /// Subsystem Class
    /// </summary>
    public class CustomerDiscountBaseService
    {
        public double CalculateDiscountBase(int customerId)
        {
            return (customerId > 8) ? 10 : 20;
        }
    }

    /// <summary>
    /// Subsystem Class
    /// </summary>
    public class DayOfTheWeekFactorService
    {
        public double CalculateDayOfTheWeekFactor()
        {
            return DateTime.UtcNow.DayOfWeek switch
            {
                DayOfWeek.Sunday or DayOfWeek.Saturday => 0.8,
                _ => 1.2,
            };
        }
    }
}

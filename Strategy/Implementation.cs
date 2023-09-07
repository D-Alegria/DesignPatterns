namespace Strategy
{
    /// <summary>
    /// Strategy
    /// This declares an interface common to all supported algorithms.
    /// CONTEXT uses this interface to call the algorithm defined by a
    /// CONCRETE STRATEGY
    /// </summary>
    public interface IExportService
    {
        void Export(Order order);
    }

    /// <summary>
    /// Concrete Strategy
    /// This an implementation of the STRATEGY interface.
    /// It also houses the algorithms for the STRATEGY
    /// </summary>
    public class CSVExportServce : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} to CSV");
        }
    }

    // <summary>
    /// Concrete Strategy
    /// This an implementation of the STRATEGY interface.
    /// It also houses the algorithms for the STRATEGY
    /// </summary>
    public class XMLExportServce : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} to XML");
        }
    }

    // <summary>
    /// Concrete Strategy
    /// This an implementation of the STRATEGY interface.
    /// It also houses the algorithms for the STRATEGY
    /// </summary>
    public class JSONExportServce : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} to JSON");
        }
    }

    /// <summary>
    /// Context
    /// This is configured with a CONCRETE STRATEGY object and maintains a
    /// reference to a STRATEGY object()
    /// </summary>
    public class Order
    {
        public IExportService? ExportService { get; set; }
        public string Name { get; set; }
        public string Customer { get; set; }
        public int Amount { get; set; }
        public string? Description { get; set; }

        public Order(string customer, string name, int amount)
        {
            Customer = customer;
            Name = name;
            Amount = amount;
        }

        public void Export()
        {
            ExportService?.Export(this);
        }
    }

    /// <summary>
    /// Context - Strategy Pattern Variation with Method Parameter
    /// This is configured with a CONCRETE STRATEGY object and maintains a
    /// reference to a STRATEGY object()
    /// </summary>
    public class OrderWithMethodParameter : Order
    {

        public OrderWithMethodParameter(string customer, string name, int amount) : base(customer, name, amount)
        {
        }

        public void Export(IExportService exportService)
        {
            if (exportService is null)
            {
                throw new ArgumentNullException(nameof(exportService));
            }

            exportService?.Export(this);
        }
    }
}

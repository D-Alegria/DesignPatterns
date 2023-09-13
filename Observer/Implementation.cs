namespace Observer
{
    public class TicketChange
    {
        public int Amount { get; private set; }
        public int ArtistId { get; private set; }

        public TicketChange(int amount, int artistId)
        {
            Amount = amount;
            ArtistId = artistId;
        }
    }

    /// <summary>
    /// Observer
    /// This defines an updating interface for objects that should be notified
    /// of changes in a Subject
    /// </summary>
    public interface ITicketChangeListener
    {
        void ReceiveTicketChangeNotification(TicketChange ticketChange);
    }

    /// <summary>
    /// ConcreteObserver
    /// This store state that must remain consistent with the Subjects state.
    /// They implement the Observer updating interface to keep state consistent.
    /// </summary>
    public class TicketStockService : ITicketChangeListener
    {
        public void ReceiveTicketChangeNotification(TicketChange ticketChange)
        {
            Console.WriteLine($"{nameof(TicketStockService)} notified of " +
              $"ticket change: artist {ticketChange.ArtistId}, " +
              $"amount {ticketChange.Amount}");
        }
    }

    /// <summary>
    /// ConcreteObserver
    /// This store state that must remain consistent with the Subjects state.
    /// They implement the Observer updating interface to keep state consistent.
    /// </summary>
    public class TicketResellerService : ITicketChangeListener
    {
        public void ReceiveTicketChangeNotification(TicketChange ticketChange)
        {
            Console.WriteLine($"{nameof(TicketResellerService)} notified of " +
                $"ticket change: artist {ticketChange.ArtistId}, " +
                $"amount {ticketChange.Amount}");
        }
    }

    /// <summary>
    /// Subject
    /// This knows it's Observers. It provides an interface for attaching and
    /// detaching them.
    /// </summary>
    public abstract class TicketChangeNotifier
    {
        private List<ITicketChangeListener> _observers = new();

        public void AddObserver(ITicketChangeListener observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(ITicketChangeListener observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(TicketChange ticketChange)
        {
            foreach (var observer in _observers)
            {
                observer.ReceiveTicketChangeNotification(ticketChange);
            }
        }
    }

    /// <summary>
    /// ConcreteSubject
    /// This stores state of interest to ConcreteObserver objects, and sends a
    /// notification to its Observers when it's state changes.
    /// </summary>
    public class OrderService: TicketChangeNotifier
    {
        public void CompleteTicketSale(int artistId, int amount)
        {
            // Mimicking DB Update
            Console.WriteLine($"{nameof(OrderService)} is changing it's state.");
            Console.WriteLine($"{nameof(OrderService)} is notifying observers...");
            Notify(new TicketChange(artistId, amount));

        }
    }
}

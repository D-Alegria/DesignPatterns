namespace Decorator
{
    /// <summary>
    /// Component (as interface)
    /// Defines the interface for objects that can have responsibilities
    /// added to them dynamically
    /// </summary>
    public interface IMailService
    {
        bool SendMail(string message);
    }

    /// <summary>
    /// ConcreteComponent
    /// This defines an object to which additional responisilities can
    /// be attached
    /// </summary>
    public class OnPremiseMailService : IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine($"{message} was sent via {nameof(OnPremiseMailService)}");
            return true;
        }
    }

    /// <summary>
    /// ConcreteComponent
    /// This defines an object to which additional responisilities can
    /// be attached
    /// </summary>
    public class CloudMailService : IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine($"{message} was sent via {nameof(CloudMailService)}");
            return true;
        }
    }

    /// <summary>
    /// Decorator
    /// This maintains a reference to a 'Component' object and defines an
    /// interface that conforms to 'Components' interface.
    /// </summary>
    public abstract class MailServiceDecoratorBase : IMailService
    {
        private readonly IMailService _mailService;

        protected MailServiceDecoratorBase(IMailService mailService)
        {
            _mailService = mailService;
        }

        public virtual bool SendMail(string message)
        {
            return _mailService.SendMail(message);
        }
    }

    /// <summary>
    /// Concrete Decorator
    /// Adds responsibilites to the component
    /// </summary>
    public class StatisticsDecorator : MailServiceDecoratorBase
    {
        public StatisticsDecorator(IMailService mailService) : base(mailService)
        {
        }

        public override bool SendMail(string message)
        {
            Console.WriteLine($"Collecting statistics in {nameof(StatisticsDecorator)}");
            return base.SendMail(message);
        }
    }

    /// <summary>
    /// Concrete Decorator
    /// Adds responsibilites to the component
    /// </summary>
    public class MessageDatabaseDecorator : MailServiceDecoratorBase
    {
        public MessageDatabaseDecorator(IMailService mailService) : base(mailService)
        {
        }

        public override bool SendMail(string message)
        {
            Console.WriteLine($"Messaging Database in {nameof(MessageDatabaseDecorator)}");
            return base.SendMail(message);
        }
    }
}

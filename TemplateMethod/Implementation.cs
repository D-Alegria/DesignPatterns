namespace TemplateMethod
{
    /// <summary>
    /// AbstractClass
    /// This defines abstract primitive operations that concrete
    /// subclasses define to implement steps of an algorithm.
    /// This also implements a template method which defines the skeleton of an
    /// algorithm
    /// </summary>
    public abstract class MailParser
    {
        /// <summary>
        /// TemplateMethod
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public string ParseMailBody(string identifier)
        {
            Console.WriteLine("Parsing mail body (in template method)...");
            FindServer();
            AuthenticateToServer();
            return ParseHtmlMailBody(identifier);
        }

        public virtual void FindServer()
        {
            Console.WriteLine("Finding server...");
        }

        public abstract void AuthenticateToServer();

        public string ParseHtmlMailBody(string identifier)
        {
            Console.WriteLine("Parsing HTML mail body...");
            return $"This is the body of mail with id {identifier}";
        }
    }

    /// <summary>
    /// ConcreteClass
    /// This implements the primitive operations to carry out subclass-specific
    /// steps of the algorithm.
    /// </summary>
    public class ExchangeMailParser : MailParser
    {
        public override void AuthenticateToServer()
        {
            Console.WriteLine("Connecting to Exchange");
        }
    }

    /// <summary>
    /// ConcreteClass
    /// This implements the primitive operations to carry out subclass-specific
    /// steps of the algorithm.
    /// </summary>
    public class ApacheMailParser : MailParser
    {
        public override void AuthenticateToServer()
        {
            Console.WriteLine("Connecting to Apache");
        }
    }

    /// <summary>
    /// ConcreteClass
    /// This implements the primitive operations to carry out subclass-specific
    /// steps of the algorithm.
    /// </summary>
    public class GoogleMailParser : MailParser
    {
        public override void AuthenticateToServer()
        {
            Console.WriteLine("Connecting to Google");
        }

        public override void FindServer()
        {
            Console.WriteLine("Finding Google server through a custom algorithm...");
        }
    }

}

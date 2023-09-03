namespace Proxy
{
    /// <summary>
    /// Subject
    /// This defines the common interface between the RealSubject and the Proxy.
    /// </summary>
    public interface IDocument
    {
        void DisplayDocument();
    }

    /// <summary>
    /// RealSubject
    /// This defines the real object that the proxy presents.
    /// </summary>
    public class Document : IDocument
    {
        public string? Title { get; private set; }
        public string? Content { get; private set; }
        public int AuthorId { get; private set; }
        public DateTimeOffset? LastAccessed { get; private set; }

        private string _fileName;

        public Document(string fileName)
        {
            _fileName = fileName;
            LoadDocument(fileName);
        }

        public void request()
        {
            throw new NotImplementedException();
        }

        private void LoadDocument(string fileName)
        {
            Console.WriteLine($"Executing expensive actionL loading file {fileName} from disk");
            Thread.Sleep(2000);
            Title = "An expensive document";
            Content = "Lots and lots of content";
            AuthorId = 1;
            LastAccessed = DateTimeOffset.UtcNow;
        }

        public void DisplayDocument()
        {
            Console.WriteLine($"Title: {Title}, Content: {Content}");
        }
    }


    /// <summary>
    /// Proxy
    /// This provides an interface indentical to the SUBJECT. It maintained a
    /// reference to and controls access to the RealSubject
    /// </summary>
    public class DocumentProxy : IDocument
    {
        private Lazy<Document> _document;
        private string _fileName;

        public DocumentProxy(string fileName)
        {
            _fileName = fileName;
            _document = new Lazy<Document>(() => new Document(_fileName));
        }

        public void DisplayDocument()
        {
            // avoid creating the doc until we need it
            _document.Value.DisplayDocument();
        }
    }

    /// <summary>
    /// Proxy
    /// This provides an interface indentical to the SUBJECT. It maintained a
    /// reference to and controls access to the RealSubject
    /// </summary>
    public class ProtectedDocumentProxy : IDocument
    {
        private DocumentProxy _documentProxy;
        private string _fileName;
        private string _userRole;

        public ProtectedDocumentProxy(string fileName, string userRole)
        {
            _fileName = fileName;
            _userRole = userRole;
            _documentProxy = new DocumentProxy(fileName);
        }

        public void DisplayDocument()
        {
            Console.WriteLine($"Entering DisplayDocument in {nameof(ProtectedDocumentProxy)}");

            if (!_userRole.Equals("Viewer", StringComparison.OrdinalIgnoreCase))
            {
                throw new UnauthorizedAccessException();
            }

            _documentProxy.DisplayDocument();

            Console.WriteLine($"Exiting DisplayDocument in {nameof(ProtectedDocumentProxy)}");
        }
    }
}
    
using System.ComponentModel.DataAnnotations;

namespace ChainOfResponsibility
{
    /// <summary>
    /// Handler
    /// This defines an interface for handling requests, and optionally
    /// implements the successor link
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IHandler<T> where T : class
    {
        void Handle(T request);
        IHandler<T> SetSuccessor(IHandler<T> successor);
    }

    /// <summary>
    /// ConcreteHandler
    /// This handle requests it's responsible for. It can access the successor
    /// and potentially pass the request on.
    /// </summary>
    /// <typeparam name="Document"></typeparam>
    public class DocumentTitleHandler : IHandler<Document>
    {

        private IHandler<Document>? _successor;
        public void Handle(Document request)
        {
            if (request.Title == string.Empty)
            {
                throw new ValidationException(new ValidationResult("Title must be filled out", new List<string>() { "Title" }), null, null);
            }
            // go to the next handler
            _successor?.Handle(request);
        }

        public IHandler<Document> SetSuccessor(IHandler<Document> successor)
        {
            _successor = successor;
            return successor;
        }
    }

    /// <summary>
    /// ConcreteHandler
    /// This handle requests it's responsible for. It can access the successor
    /// and potentially pass the request on.
    /// </summary>
    /// <typeparam name="Document"></typeparam>
    public class DocumentLastModifiedHandler : IHandler<Document>
    {
        private IHandler<Document>? _successor;
        public void Handle(Document request)
        {
            if (request.LastModified < DateTime.UtcNow.AddDays(-30))
            {
                throw new ValidationException(new ValidationResult("Document must be modified in the last 30 days", new List<string>() { "LastModified" }), null, null);
            }
            // go to the next handler
            _successor?.Handle(request);
        }

        public IHandler<Document> SetSuccessor(IHandler<Document> successor)
        {
            _successor = successor;
            return successor;
        }
    }

    /// <summary>
    /// ConcreteHandler
    /// This handle requests it's responsible for. It can access the successor
    /// and potentially pass the request on.
    /// </summary>
    /// <typeparam name="Document"></typeparam>
    public class DocumentApprovedByLitigationHandler : IHandler<Document>
    {
        private IHandler<Document>? _successor;
        public void Handle(Document request)
        {
            if (!request.ApprovedByLitigation)
            {
                throw new ValidationException(new ValidationResult("Document must be approved by litigation", new List<string>() { "ApprovedByLitigation" }), null, null);
            }
            // go to the next handler
            _successor?.Handle(request);
        }

        public IHandler<Document> SetSuccessor(IHandler<Document> successor)
        {
            _successor = successor;
            return successor;
        }
    }

    /// <summary>
    /// ConcreteHandler
    /// This handle requests it's responsible for. It can access the successor
    /// and potentially pass the request on.
    /// </summary>
    /// <typeparam name="Document"></typeparam>
    public class DocumentApprovedByManagementHandler : IHandler<Document>
    {
        private IHandler<Document>? _successor;
        public void Handle(Document request)
        {
            if (!request.ApprovedByManagement)
            {
                throw new ValidationException(new ValidationResult("Document must be approved by managment", new List<string>() { "ApprovedByManagement" }), null, null);
            }
            // go to the next handler
            _successor?.Handle(request);
        }

        public IHandler<Document> SetSuccessor(IHandler<Document> successor)
        {
            _successor = successor;
            return successor;
        }
    }

    public class Document
    {
        public string Title { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public bool ApprovedByLitigation { get; set; }
        public bool ApprovedByManagement { get; set; }

        public Document(string title, DateTimeOffset lastModified, bool approvedByLitigation, bool approvedByManagement)
        {
            Title = title;
            LastModified = lastModified;
            ApprovedByLitigation = approvedByLitigation;
            ApprovedByManagement = approvedByManagement;
        }
    }
}
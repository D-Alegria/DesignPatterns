namespace Composite
{
    /// <summary>
    /// Component
    /// This declares the interface for objects on the composition and contains
    /// a common operation
    /// </summary>
    public abstract class FileSystemItem
    {
        public String Name { get; set; }
        public abstract long GetSize();

        public FileSystemItem(string name)
        {
            Name = name;
        }
    }

    /// <summary>
    /// Leaf
    /// This represents leaf objects in the composition, and has no children. It
    /// defines behaviour for primitive objects in the composition.
    /// </summary>
    public class File : FileSystemItem
    {
        private long _size;
        public File(string name, long size) : base(name)
        {
            _size = size;
        }

        public override long GetSize()
        {
            return _size;
        }
    }

    /// <summary>
    /// Composite
    /// This stores child components and defines behaviour for components having
    /// children.
    /// </summary>
    public class Directory : FileSystemItem
    {
        private long _size;
        private List<FileSystemItem> _items = new();

        public Directory(string name,long size) : base(name)
        {
            _size = size;
        }

        public override long GetSize()
        {
            return _size + _items.Select(item => item.GetSize()).Sum();
        }

        public void AddFileSystemItem(FileSystemItem file)
        {
            _items.Add(file);
        }

        public void RemoveFileSystemItem(FileSystemItem file)
        {
            _items.Remove(file);
        }
    }
}

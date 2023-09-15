namespace Iterator
{
    public class Person
    {
        public string Name { get; set; }
        public string Country { get; set; }

        public Person(string name, string country)
        {
            Name = name;
            Country = country;
        }
    }

    /// <summary>
    /// Iterator
    /// This defines an interface for accessing and traversing elements.
    /// </summary>
    public interface IPeopleIterator
    {
        Person First();
        Person Next();
        bool IsDone { get; }
        Person CurrentItem { get; }
    }

    /// <summary>
    /// ConcreteIterator
    /// This implements the Iterator interface and keeps track of the current
    /// position of the Aggregate
    /// </summary>
    public class PeopleIterator : IPeopleIterator
    {
        private PeopleCollection _peopleCollection;
        private int _currentItem;

        public PeopleIterator(PeopleCollection peopleCollection)
        {
            _peopleCollection = peopleCollection;
        }

        public bool IsDone
        {
            get
            {
                return _currentItem >= _peopleCollection.Count;
            }
        }

        public Person CurrentItem
        {
            get
            {
                return _peopleCollection.OrderBy(p => p.Name).ToList()[_currentItem];
            }
        }

        public Person First()
        {
            _currentItem = 0;
            return _peopleCollection.OrderBy(p => p.Name).ToList()[_currentItem];
        }

        public Person Next()
        {
            _currentItem++;
            if (!IsDone)
                return _peopleCollection.OrderBy(p => p.Name).ToList()[_currentItem];
            else
                return null;
        }
    }

    /// <summary>
    /// Aggregate
    /// This defines an interface for creating an iterator object.
    /// </summary>
    public interface IPeopleCollection
    {
        IPeopleIterator CreateIterator();
    }

    /// <summary>
    /// ConcreteAggregate
    /// This implements the Iterator creation interface to return an instance of
    /// the proper ConcreteIterator.
    /// </summary>
    public class PeopleCollection : List<Person>, IPeopleCollection
    { 

        public IPeopleIterator CreateIterator()
        {
            return new PeopleIterator(this);
        }
    }
}

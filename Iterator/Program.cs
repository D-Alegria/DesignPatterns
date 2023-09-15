using Iterator;

Console.Title = "Iterator";

// Create the collection
PeopleCollection people = new()
{
    new Person("Demilade Oladugba", "Nigeria"), 
    new Person("Olumide Ogundare","Nigeria"),
    new Person("Abubakar Yusuf", "Nigeria"),
    new Person("Amit Dwivedi", "India"),
    new Person("Jacquelina Garrido", "Argentina")
};

// Create the Iterator
var peopleIterator = people.CreateIterator();

for (Person person = peopleIterator.First(); !peopleIterator.IsDone; person = peopleIterator.Next())
{
    Console.WriteLine(person?.Name);
}

Console.ReadKey();
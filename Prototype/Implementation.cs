using Newtonsoft.Json;

namespace Prototype
{
    /// <summary>
    /// Prototype
    /// </summary>
    public abstract class Person
    {
        public abstract string Name { get; set; }

        public abstract Person Clone(bool deepClone);
    }

    /// <summary>
    /// ConcretePrototype
    /// </summary>
    public class Manager : Person
    {
        public override string Name { get; set; }

        public Manager(string Name)
        {
            this.Name = Name;
        }

        public override Person Clone(bool deepClone = false)
        {
            if (deepClone)
            {
                var objectAsJson = JsonConvert.SerializeObject(this);
                return JsonConvert.DeserializeObject<Manager>(objectAsJson)!;
            }
            return (Person)MemberwiseClone();
        }
    }

    /// <summary>
    /// ConcretePrototype
    /// </summary>
    public class Employee : Person
    {
        public Manager Manager { get; set; }
        public override string Name { get; set; }

        public Employee(string Name, Manager manager)
        {
            this.Name = Name;
            Manager = manager;
        }

        public override Person Clone(bool deepClone = false)
        {
            if (deepClone)
            {
                var objectAsJson = JsonConvert.SerializeObject(this);
                return JsonConvert.DeserializeObject<Employee>(objectAsJson)!;
            }
            return (Person)MemberwiseClone();
        }
    }
}

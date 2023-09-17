namespace Visitor
{
    /// <summary>
    /// Element
    /// This defines an accept operation that takes a Visitor as an argument
    /// </summary>
    public interface IElement
    {
        void Accept(IVisitor visitor);
    }

    /// <summary>
    /// ConcreteElement
    /// This implement the accept operation that takes a Visitor as an argument
    /// </summary>
    public class Customer : IElement
    {
        public decimal AmountOrdered { get; private set; }
        public decimal Discount { get; set; }
        public string Name { get; private set; }

        public Customer(decimal amountOrdered, string name)
        {
            AmountOrdered = amountOrdered;
            Name = name;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            Console.WriteLine($"Visited {nameof(Customer)} {Name}, discount given: {Discount}");
        }
    }

    /// <summary>
    /// ConcreteElement
    /// This implement the accept operation that takes a Visitor as an argument
    /// </summary>
    public class Employee : IElement
    {

        public decimal YearsEmployed { get; private set; }
        public decimal Discount { get; set; }
        public string Name { get; private set; }

        public Employee(decimal yearsEmployed, string name)
        {
            YearsEmployed = yearsEmployed;
            Name = name;
        }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            Console.WriteLine($"Visited {nameof(Employee)} {Name}, discount given: {Discount}");
        }
    }

    /// <summary>
    /// Visitor
    /// This declares a visit operation for each class of the Concrete Element in
    /// the Object Structure
    /// </summary>
    public interface IVisitor
    {
        // Option 1
        //void VisitCustomer(Customer customer);
        //void VisitEmployee(Employee employee);
        // Option 2
        void Visit(IElement element);
    }

    /// <summary>
    /// ConcreteVisitor
    /// This implements each operation declared by the Visitor
    /// </summary>
    public class DiscountVisitor : IVisitor
    {
        public decimal TotalDiscountGiven { get; set; }

        public void Visit(IElement element)
        {
            if (element is Customer customer)
            {
                VisitCustomer(customer);
            }   

            if (element is Employee employee)
            {
                VisitEmployee(employee);
            }
        }

        private void VisitCustomer(Customer customer)
        {
            var discount = customer.AmountOrdered / 10;
            customer.Discount = discount;
            TotalDiscountGiven += discount;
        }

        private void VisitEmployee(Employee employee)
        {
            var discount = employee.YearsEmployed < 10 ? 100 : 200; ;
            employee.Discount = discount;
            TotalDiscountGiven += discount;
        }
    }

    public class Container
    {
        public List<Employee> Employees { get; set; } = new();
        public List<Customer> Customers { get; set; } = new();

        public void Accept(IVisitor visitor)
        {
            foreach(var employee in Employees)
            {
                employee.Accept(visitor);
            }
            foreach(var customer in Customers)
            {
                customer.Accept(visitor);
            }
        }
    }
}

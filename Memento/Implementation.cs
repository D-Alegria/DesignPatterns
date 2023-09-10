namespace Memento
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Employee(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class Manager : Employee
    {
        public List<Employee> Employees = new();

        public Manager(int id, string name) : base(id, name)
        {
        }
    }

    /// <summary>
    /// Invoker
    /// This asks Command to carry out a request
    /// Caretaker
    /// This keeps the Memento safe, and shouldn't operate on or examine
    /// it's content
    /// </summary>
    public class CommandManager
    {
        private readonly Stack<AddEmployeeToManagerListMemento> _mementos = new();
        private AddEmployeeToManagerList? _command;

        public void Invoke(ICommand command)
        {
            _command ??= (AddEmployeeToManagerList)command;
            if (command.CanExecute())
            {
                command.Execute();
                _mementos.Push(((AddEmployeeToManagerList)command).CreateMemento());
            }
        }

        public void Undo()
        {
            if (_mementos.Any())
            {
                _command?.RestoreMemento(_mementos.Pop());
                _command?.Undo();
            }
        }

        public void UndoAll()
        {
            while (_mementos.Any())
            {
                _command?.RestoreMemento(_mementos.Pop());
                _command?.Undo();
            }
        }
    }

    /// <summary>
    /// Command
    /// This declares an interface for executing an operation
    /// </summary>
    public interface ICommand
    {
        void Execute();
        bool CanExecute();
        void Undo();
    }

    /// <summary>
    /// ConcreteCommand
    /// This defines a binding between a Receiver and an action. It implements
    /// Execute by invoking the corresponding operation(s) on Receiver.
    /// Originator
    /// It is responsible for creating  a Memento with a snapshot of it's internal
    /// state. It is also uses the Memento to restore it's internal state.
    /// </summary>
    public class AddEmployeeToManagerList : ICommand
    {
        private readonly IEmployeeManagerRepository _employeeManagerRepository;
        private int _managerId;
        private Employee? _employee;

        public AddEmployeeToManagerList(IEmployeeManagerRepository employeeManagerRepository, int managerId, Employee? employee)
        {
            _employeeManagerRepository = employeeManagerRepository;
            _managerId = managerId;
            _employee = employee;
        }

        public AddEmployeeToManagerListMemento CreateMemento()
        {
            return new AddEmployeeToManagerListMemento(_managerId, _employee);
        }

        public void RestoreMemento(AddEmployeeToManagerListMemento memento)
        {
            _managerId = memento.ManagerId;
            _employee = memento.Employee;
        }

        public bool CanExecute()
        {
            return _employee != null && !_employeeManagerRepository.HasEmployee(_managerId, _employee.Id);
        }

        public void Execute()
        {
            if (_employee == null) return;
            _employeeManagerRepository.AddEmployee(_managerId, _employee);
        }

        public void Undo()
        {
            if (_employee == null) return;
            _employeeManagerRepository.RemoveEmployee(_managerId, _employee);
        }
    }

    /// <summary>
    /// Receiver (interface)
    /// This knows how to perform the operations associated with carrying out a
    /// request
    /// </summary>
    public interface IEmployeeManagerRepository
    {
        void AddEmployee(int managerId, Employee employee);
        void RemoveEmployee(int managerId, Employee employee);
        bool HasEmployee(int managerId, int employeeId);
        void WriteToDataStore();
    }

    /// <summary>
    /// Receiver (implementation)
    /// This knows how to perform the operations associated with carrying out a
    /// request
    /// </summary>
    public class EmployeeManagetRepository : IEmployeeManagerRepository
    {
        private List<Manager> _managers = new List<Manager>()
        {
            new Manager(1, "Demilade"),
            new Manager(2, "Temilade")
        };

        public void AddEmployee(int managerId, Employee employee)
        {
            _managers.First(m => m.Id == managerId).Employees.Add(employee);
        }

        public bool HasEmployee(int managerId, int employeeId)
        {
            return _managers.First(m => m.Id == managerId).Employees.Any(e => e.Id == employeeId);
        }

        public void RemoveEmployee(int managerId, Employee employee)
        {
            _managers.First(m => m.Id == managerId).Employees.Remove(employee);
        }

        public void WriteToDataStore()
        {
            foreach (var manager in _managers)
            {
                Console.WriteLine($"Manager {manager.Id}, {manager.Name}");
                if (manager.Employees.Any())
                {
                    foreach (var employee in manager.Employees)
                    {
                        Console.WriteLine($"\t Employee {employee.Id}, {employee.Name}");
                    }
                }
                else
                {
                    Console.WriteLine($"\t No employees");
                }
            }
        }
    }
    /// <summary>
    /// Memento
    /// It is responsible for storing the internal state of the originator. The
    /// state should be protected against accesss by other objects as much as
    /// possible.
    /// </summary>
    public class AddEmployeeToManagerListMemento
    {
        public int ManagerId { get; private set; }
        public Employee? Employee { get; private set; }

        public AddEmployeeToManagerListMemento(int managerId, Employee? employee)
        {
            ManagerId = managerId;
            Employee = employee;
        }
    }

}
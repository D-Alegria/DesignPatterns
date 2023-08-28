using Prototype;

Console.Title = "Prototype";

var manager = new Manager("Demilade");
var managerClone = (Manager)manager.Clone();
Console.WriteLine($"Manager was cloned: {managerClone.Name}");

var employee = new Employee("Ismail", managerClone);
var employeeClone = (Employee)employee.Clone(true);
Console.WriteLine($"Employee was cloned: {employeeClone.Name}, with manager {employeeClone.Manager.Name}");

// change manager name
managerClone.Name = "Ibukun";
Console.WriteLine($"Employee was cloned: {employeeClone.Name}, with manager {employeeClone.Manager.Name}");

Console.ReadKey();
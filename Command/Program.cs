using Command;

Console.Title = "Command";

CommandManager commandManager = new();
IEmployeeManagerRepository repository = new EmployeeManagetRepository();

commandManager.Invoke(new AddEmployeeToManagerList(repository, 1, new Employee(111, "Toby")));
repository.WriteToDataStore();

commandManager.Undo();
repository.WriteToDataStore();

commandManager.Invoke(new AddEmployeeToManagerList(repository, 1, new Employee(222, "Clara")));
repository.WriteToDataStore();
commandManager.Invoke(new AddEmployeeToManagerList(repository, 2, new Employee(333, "Tom")));
repository.WriteToDataStore();

// Adding the same employee twice
commandManager.Invoke(new AddEmployeeToManagerList(repository, 2, new Employee(333, "Tom")));
repository.WriteToDataStore();

commandManager.UndoAll();
repository.WriteToDataStore();

Console.ReadKey();
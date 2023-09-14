using State;

Console.Title = "State";

BankAccount bankAccount = new();
bankAccount.Deposit(100);
bankAccount.Withdraw(700);
bankAccount.Withdraw(100);
// deposit enough to go to gold
bankAccount.Deposit(2000);
// Validate gold state
bankAccount.Deposit(100);
// Back to overdraw
bankAccount.Withdraw(4000);
// should transition to regular
bankAccount.Deposit(4000);
// Be in regular
bankAccount.Deposit(100);

Console.ReadKey();
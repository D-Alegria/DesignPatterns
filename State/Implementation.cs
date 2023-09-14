namespace State
{
    /// <summary>
    /// Context
    /// This defines the interface that's of interest to clients. It maintains
    /// an instance of a ConcreteState subclass that defines the current state.
    /// </summary>
    public class BankAccount
    {
        public BankAccountState BankAccountState { get; set; }
        public decimal Balance { get { return BankAccountState.Balance; } }

        public BankAccount()
        {
            BankAccountState = new RegularState(200, this);
        }

        public void Deposit(decimal amount)
        {
            BankAccountState.Deposit(amount);
        }

        public void Withdraw(decimal amount)
        {
            BankAccountState.Withdraw(amount);
        }
    }

    /// <summary>
    /// State
    /// This defines an interface for encapsulating the behavior associated with
    /// a particular state of the Context.
    /// </summary>
    public abstract class BankAccountState
    {
        public BankAccount BankAccount { get; protected set; } = null!;
        public decimal Balance { get; protected set; }
        public abstract void Deposit(decimal amount);
        public abstract void Withdraw(decimal amount);
    }

    /// <summary>
    /// ConcreteState
    /// This implements behavior associated with a state of the Context
    /// </summary>
    public class GoldState : BankAccountState
    {
        public GoldState(decimal balance, BankAccount bankAccount)
        {
            Balance = balance;
            BankAccount = bankAccount;
        }

        public override void Deposit(decimal amount)
        {
            Console.WriteLine($"In {GetType()}, depositing {amount} + 10% bonus: {amount / 10}");
            Balance += amount + (amount / 10);
        }

        public override void Withdraw(decimal amount)
        {
            Console.WriteLine($"{GetType()}, withdrawing {amount} from {Balance}");
            Balance -= amount;
            if (Balance < 1000 && Balance >= 0)
            {
                BankAccount.BankAccountState = new RegularState(Balance, BankAccount);
            }
            else if (Balance < 0)
            {
                BankAccount.BankAccountState = new OverdrawnState(Balance, BankAccount);
            }
        }
    }

    /// <summary>
    /// ConcreteState
    /// This implements behavior associated with a state of the Context
    /// </summary>
    public class RegularState : BankAccountState
    {
        public RegularState(decimal balance, BankAccount bankAccount)
        {
            Balance = balance;
            BankAccount = bankAccount;
        }

        public override void Deposit(decimal amount)
        {
            Console.WriteLine($"{GetType()}, depositing {amount}");
            Balance += amount;
            if (Balance > 1000)
            {
                BankAccount.BankAccountState = new GoldState(Balance, BankAccount);
            }
        }

        public override void Withdraw(decimal amount)
        {
            Console.WriteLine($"{GetType()}, withdrawing {amount} from {Balance}");
            Balance -= amount;
            if (Balance < 0)
            {
                BankAccount.BankAccountState = new OverdrawnState(Balance, BankAccount);
            }
        }
    }

    /// <summary>
    /// ConcreteState
    /// This implements behavior associated with a state of the Context
    /// </summary>
    public class OverdrawnState : BankAccountState
    {
        public OverdrawnState(decimal balance, BankAccount bankAccount)
        {
            Balance = balance;
            BankAccount = bankAccount;
        }

        public override void Deposit(decimal amount)
        {
            Console.WriteLine($"{GetType()}, depositing {amount}");
            Balance += amount;
            if (Balance >= 0)
            {
                BankAccount.BankAccountState = new RegularState(Balance, BankAccount);
            }
        }

        public override void Withdraw(decimal amount)
        {
            Console.WriteLine($"In {GetType()}, cannot withdraw, balance {Balance}");

        }
    }
}

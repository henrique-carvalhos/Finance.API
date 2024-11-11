namespace Finance.Core.Entities
{
    public class Expense : BaseEntity
    {
        public Expense(string description, decimal amount, DateTime dateExpense, int idUser, int idExpenseCategory, int idExpenseType)
            : base()
        {
            Description = description;
            Amount = amount;
            DateExpense = dateExpense;

            IdUser = idUser;
            IdExpenseCategory = idExpenseCategory;
            IdExpenseType = idExpenseType;
        }

        public string Description { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime DateExpense { get;  private set; }

        public int IdUser { get; private set; }
        public User User { get; private set; }

        public int IdExpenseCategory { get; private set; }
        public ExpenseCategory ExpenseCategory { get; private set; }

        public int IdExpenseType { get; private set; }
        public ExpenseType ExpenseType { get; private set; }

        public void Update(string description, decimal amount, DateTime dateExpense, int idUser, int idExpenseCategory, int idExpenseType)
        {
            Description = description;
            Amount = amount;
            DateExpense = dateExpense;

            IdUser = idUser;
            IdExpenseCategory = idExpenseCategory;
            IdExpenseType = idExpenseType;
        }
    }
}

using Finance.Core.Entities;

namespace Finance.Application.Models
{
    public class ExpenseViewModel
    {
        public ExpenseViewModel(int id, string description, decimal amount, DateTime dateExpense, string card,string nameUser, string nameExpenseCategory, string nameExpenseType)
        {
            Id = id;
            Description = description;
            Amount = amount;
            DateExpense = dateExpense;
            Card = card;
            NameUser = nameUser;
            NameExpenseCategory = nameExpenseCategory;
            NameExpenseType = nameExpenseType;
        }

        public int Id { get; private set; }     
        public string Description { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime DateExpense { get; private set; }
        public string Card { get; set; }
        public string NameUser { get; private set; }
        public string NameExpenseCategory { get; private set; }
        public string NameExpenseType { get; private set; }

        public static ExpenseViewModel FromEntity(Expense expense)
            => new(expense.Id, expense.Description, expense.Amount, expense.DateExpense, expense.Card.ToString(),expense.User.Name, expense.ExpenseCategory.Name, expense.ExpenseType.Name);
    }
}

using Finance.Core.Entities;

namespace Finance.Application.Models
{
    public class CreateExpenseInputModel
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateExpense { get; set; }
        public int IdUser { get; set; }
        public int IdExpenseCategory { get; set; }
        public int IdExpenseType { get; set; }

        public Expense ToEntity()
            => new(Description, Amount, DateExpense, IdUser, IdExpenseCategory, IdExpenseType);
    }
}

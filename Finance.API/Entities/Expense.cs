namespace Finance.API.Entities
{
    public class Expense
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int ExpenseCategoryId { get; set; }
        public ExpenseCategory ExpenseCategory { get; set; }

        public int ExpenseTypeId { get; set; }
        public ExpenseType ExpenseType { get; set; }
    }
}

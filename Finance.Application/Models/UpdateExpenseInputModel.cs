namespace Finance.Application.Models
{
    public class UpdateExpenseInputModel
    {
        public int IdExpense { get; set; }
        public string Description { get;  set; }
        public decimal Amount { get;  set; }
        public DateTime DateExpense { get;  set; }

        public int IdUser { get;  set; }
        public int IdExpenseCategory { get;  set; }
        public int IdExpenseType { get;  set; }
        public int IdPaymentType { get; set; }
    }
}

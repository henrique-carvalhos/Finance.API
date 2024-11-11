namespace Finance.Application.Models
{
    public class UpdateExpenseTypeInputModel
    {
        public int IdExpenseType { get; set; }
        public string Name { get; set; }
        public int IdExpenseCategory { get; set; }
    }
}

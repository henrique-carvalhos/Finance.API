using Finance.API.Enums;

namespace Finance.API.Entities
{
    public class Income
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public IncomeType IncomeType { get; set; } // Enum para tipos de receita
        public int UserId { get; set; }
        public User User { get; set; }
    }
}

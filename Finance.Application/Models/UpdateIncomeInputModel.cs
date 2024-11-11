using Finance.Core.Enums;

namespace Finance.Application.Models
{
    public class UpdateIncomeInputModel
    {
        public int IdIncome { get; set; }
        public string Description { get;  set; }
        public decimal Amount { get;  set; }
        public DateTime Date { get;  set; }
        public IncomeType IncomeType { get;  set; } 
        public int IdUser { get;  set; }
    }
}

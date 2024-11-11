using Finance.Core.Enums;

namespace Finance.Core.Entities
{
    public class Income : BaseEntity
    {
        public Income(string description, decimal amount, DateTime date, IncomeType incomeType, int idUser)
        {
            Description = description;
            Amount = amount;
            Date = date;
            IncomeType = incomeType;
            IdUser = idUser;
        }

        public string Description { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }
        public IncomeType IncomeType { get; private set; } // Enum para tipos de receita
        public int IdUser { get; private set; }
        public User User { get; set; }

        public void Update(string description, decimal amount, DateTime date, IncomeType incomeType, int idUser)
        {
            Description = description;
            Amount = amount;
            Date = date;
            IncomeType = incomeType;
            IdUser = idUser;
        }
    }
}

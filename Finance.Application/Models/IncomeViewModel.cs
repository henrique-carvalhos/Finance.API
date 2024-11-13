using Finance.Core.Entities;

namespace Finance.Application.Models
{
    public class IncomeViewModel
    {
        public IncomeViewModel(int idIncome, bool isDeleted, string description, decimal amount, DateTime date, string incomeType, string nameUser)
        {
            IdIncome = idIncome;
            IsDeleted = isDeleted;
            Description = description;
            Amount = amount;
            Date = date;
            IncomeType = incomeType;
            NameUser = nameUser;
        }

        public int IdIncome { get; private set; }
        public bool IsDeleted { get; private set; }
        public string Description { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }
        public string IncomeType { get; private set; }
        public string NameUser { get; private set; }

        public static IncomeViewModel FromEntity(Income income)
            => new(income.Id, income.IsDeleted, income.Description, income.Amount, income.Date, income.IncomeType.ToString(), income.User.Name);
    }
}

using Finance.Core.Entities;

namespace Finance.Application.Models
{
    public class ExpenseTypeViewModel
    {
        public ExpenseTypeViewModel(int id, string name, int idExpenseCategory, bool isDeleted)
        {
            Id = id;
            Name = name;
            IdExpenseCategory = idExpenseCategory;
            IsDeleted = isDeleted;
        }

        public int Id { get; private set; }
        public string Name { get; private set; } // Energia, Água, Ifood, Festas, Metas etc.
        public int IdExpenseCategory { get; private set; }
        public bool IsDeleted { get; private set; }

        public static ExpenseTypeViewModel FromEntity(ExpenseType type)
        => new(type.Id, type.Name, type.IdExpenseCategory, type.IsDeleted);

    }
}

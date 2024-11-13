using Finance.Core.Entities;

namespace Finance.Application.Models
{
    public class ExpenseCategoryViewModel
    {
        public ExpenseCategoryViewModel(int id, string name, bool isDeleted)
        {
            Id = id;
            Name = name;
            IsDeleted = isDeleted;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public bool IsDeleted { get; private set; }

        public static ExpenseCategoryViewModel FromEntity(ExpenseCategory expense)
            => new(expense.Id, expense.Name, expense.IsDeleted);
    }
}

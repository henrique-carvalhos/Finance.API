using Finance.Core.Entities;

namespace Finance.Core.Repositories
{
    public interface IExpenseCategoryRepository
    {
        Task<ExpenseCategory?> GetbyId(int id);
        Task<List<ExpenseCategory>> GetAll(string search);
        Task<int> Add(ExpenseCategory expenseCategory);
        Task Update(ExpenseCategory expenseCategory);
    }
}

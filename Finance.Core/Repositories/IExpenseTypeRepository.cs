using Finance.Core.Entities;

namespace Finance.Core.Repositories
{
    public interface IExpenseTypeRepository
    {
        Task<ExpenseType?> GetById(int id);
        Task<List<ExpenseType>> GetAll(string search);
        Task<int> Add(ExpenseType type);
        Task Update(ExpenseType type);
    }
}

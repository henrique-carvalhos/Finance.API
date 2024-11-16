using Finance.Core.Entities;

namespace Finance.Core.Repositories
{
    public interface IExpenseRepository
    {
        Task<Expense?> GetById(int id);
        Task<List<Expense>> GetAll(string search);
        Task<int> Add(Expense expense);
        Task Update(Expense expense);
    }
}

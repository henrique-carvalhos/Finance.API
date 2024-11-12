using Finance.Core.Entities;

namespace Finance.Core.Repositories
{
    public interface IIncomeRepository
    {
        Task<Income?> GetById(int id);
        Task<List<Income>> GetAll(string search);
        Task<int> Add(Income inocome);
        Task Update(Income income);
        Task Delete(int id);
    }
}

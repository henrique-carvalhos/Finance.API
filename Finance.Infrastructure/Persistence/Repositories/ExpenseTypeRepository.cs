using Finance.Core.Entities;
using Finance.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infrastructure.Persistence.Repositories
{
    public class ExpenseTypeRepository : IExpenseTypeRepository
    {
        private readonly FinanceDbContext _context;
        public ExpenseTypeRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(ExpenseType type)
        {
            _context.ExpensesTypes.Add(type);
            await _context.SaveChangesAsync();

            return type.Id;
        }

        public async Task<List<ExpenseType>> GetAll(string search)
        {
            var type = await _context.ExpensesTypes
               .Where(u => search == "" || u.Name.Contains(search))
               .ToListAsync();

            return type;
        }

        public async Task<ExpenseType?> GetById(int id)
        {
            return await _context.ExpensesTypes
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(ExpenseType type)
        {
            _context.Update(type);
            await _context.SaveChangesAsync();
        }
    }
}

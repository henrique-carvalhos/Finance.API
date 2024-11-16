using Finance.Core.Entities;
using Finance.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infrastructure.Persistence.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly FinanceDbContext _context;
        public ExpenseRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Expense expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();

            return expense.Id;
        }

        public async Task<List<Expense>> GetAll(string search)
        {
            var expenses = await _context.Expenses
                .Include(u => u.User)
                .Include(e => e.ExpenseCategory)
                .Include(e => e.ExpenseType)
                .Where(u => !u.IsDeleted && (search == "" || u.Description.Contains(search)))
                .ToListAsync();

            return expenses;
        }

        public async Task<Expense?> GetById(int id)
        {
            return await _context.Expenses
                .Include(u => u.User)
                .Include(e => e.ExpenseCategory)
                .Include(e => e.ExpenseType)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Expense expense)
        {
            _context.Update(expense);
            await _context.SaveChangesAsync();
        }
    }
}

using Finance.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Finance.API.Persistence
{
    public class FinanceDbContext : DbContext
    {
        public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options)
        {
            
        }

        public DbSet<User > Users { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseCategory> ExpensesCategory { get; set; }
        public DbSet<ExpenseType> ExpensesType { get; set; }
        public DbSet<Income> Incomes { get; set; }
    }
}

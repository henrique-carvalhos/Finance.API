using Finance.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infrastructure.Persistence.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly FinanceDbContext _context;
        public ExpenseRepository(FinanceDbContext context)
        {
            _context = context;
        }


    }
}

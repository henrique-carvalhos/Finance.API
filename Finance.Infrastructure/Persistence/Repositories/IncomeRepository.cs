using Finance.Core.Entities;
using Finance.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infrastructure.Persistence.Repositories
{
    public class IncomeRepository : IIncomeRepository
    {
        private readonly FinanceDbContext _context;
        public IncomeRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public Task<int> Add(Income inocome)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Income>> GetAll(string search)
        {
            throw new NotImplementedException();
        }

        public async Task<Income?> GetById(int id)
        {
            return await _context.Incomes
                .Include(i => i.User)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task Update(Income income)
        {
            throw new NotImplementedException();
        }
    }
}

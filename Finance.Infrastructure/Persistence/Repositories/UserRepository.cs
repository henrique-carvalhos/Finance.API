using Finance.Core.Entities;
using Finance.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FinanceDbContext _context;
        public UserRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public Task<int> Add(User user)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetbyId(int id)
        {
            return await _context.Users
                .Include(i => i.Incomes)
                .Include(e => e.Expenses)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}

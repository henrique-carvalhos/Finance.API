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

        public async Task<int> Add(User user)
        {
            await _context.Users.AddAsync(user);
            _context.SaveChanges();

            return user.Id;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAll(string search)
        {
            var users =  await _context.Users
                .Include(i => i.Incomes)
                .Include(e => e.Expenses)
                .Where(u => search == "" || u.Name.Contains(search))
                .ToListAsync();

            return users;
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

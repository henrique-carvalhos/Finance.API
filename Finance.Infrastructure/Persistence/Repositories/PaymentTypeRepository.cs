using Finance.Core.Entities;
using Finance.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infrastructure.Persistence.Repositories
{
    public class PaymentTypeRepository : IPaymentTypeRepository
    {
        private readonly FinanceDbContext _context;
        public PaymentTypeRepository(FinanceDbContext context)
        {
            _context = context; 
        }

        public async Task<int> Add(PaymentType payment)
        {
            _context.Add(payment);
            await _context.SaveChangesAsync();

            return payment.Id;
        }

        public async Task<List<PaymentType>> GetAll(string search)
        {
            var payment = await _context.PaymentTypes
                .Where(u => search == "" || u.Description.Contains(search))
                .ToListAsync();

            return payment;
        }

        public async Task<PaymentType?> GetById(int id)
        {
            return await _context.PaymentTypes
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(PaymentType payment)
        {
            _context.Update(payment);
            await _context.SaveChangesAsync();
        }
    }
}

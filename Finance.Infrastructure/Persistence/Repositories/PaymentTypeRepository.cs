using Finance.Core.Entities;
using Finance.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infrastructure.Persistence.Repositories
{
    public class PaymentTypeRepository : IPaymentTypeRepository
    {
        private readonly IPaymentTypeRepository _repository;
        public PaymentTypeRepository(IPaymentTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<int> Add(PaymentType payment)
        {
            throw new NotImplementedException();
        }

        public Task<List<PaymentType>> GetAll(string search)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentType?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(PaymentType payment)
        {
            throw new NotImplementedException();
        }
    }
}

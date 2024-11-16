using Finance.Core.Entities;

namespace Finance.Core.Repositories
{
    public interface IPaymentTypeRepository
    {
        Task<PaymentType?> GetById(int id);
        Task<List<PaymentType>> GetAll(string search);
        Task<int> Add(PaymentType payment);
        Task Update(PaymentType payment);
    }
}

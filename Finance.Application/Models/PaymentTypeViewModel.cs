using Finance.Core.Entities;

namespace Finance.Application.Models
{
    public class PaymentTypeViewModel
    {
        public PaymentTypeViewModel(int id, string description, bool isDeleted)
        {
            Id = id;
            Description = description;
            IsDeleted = isDeleted;
        }

        public int Id { get; private set; }
        public string Description { get; private set; }
        public bool IsDeleted { get; private set; }
    
        public static PaymentTypeViewModel FromEntity(PaymentType payment)
            => new(payment.Id, payment.Description, payment.IsDeleted);
    }
}

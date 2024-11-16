using Finance.Core.Entities;

namespace Finance.Application.Models
{
    public class CreatePaymentTypeInputModel
    {
        public string Description { get; set; }
        public PaymentType ToEntity()
            => new(Description);
    }
}

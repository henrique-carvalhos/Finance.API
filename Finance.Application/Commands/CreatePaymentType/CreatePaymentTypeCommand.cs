using Finance.Application.Models;
using Finance.Core.Entities;
using MediatR;

namespace Finance.Application.Commands.CreatePaymentType
{
    public class CreatePaymentTypeCommand : IRequest<ResultViewModel<int>>
    {
        public string Description { get; set; }

        public PaymentType ToEntity()
            => new(Description);
    }
}

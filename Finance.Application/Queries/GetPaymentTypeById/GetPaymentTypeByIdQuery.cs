using Finance.Application.Models;
using MediatR;

namespace Finance.Application.Queries.GetPaymentTypeById
{
    public class GetPaymentTypeByIdQuery : IRequest<ResultViewModel<PaymentTypeViewModel>>
    {
        public GetPaymentTypeByIdQuery(int id)
        {
            Id = id;
        }
     
        public int Id { get; set; }
    }
}

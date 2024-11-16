using Finance.Application.Models;
using MediatR;

namespace Finance.Application.Queries.GetAllPaymentType
{
    public class GetAllPaymentTypeQuery : IRequest<ResultViewModel<List<PaymentTypeViewModel>>>
    {
        public GetAllPaymentTypeQuery(string search)
        {
            Search = search;
        }

        public string Search { get; set; }
    }
}

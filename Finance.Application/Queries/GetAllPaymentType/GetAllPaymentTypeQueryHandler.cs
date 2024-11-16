using Finance.Application.Models;
using Finance.Core.Repositories;
using MediatR;

namespace Finance.Application.Queries.GetAllPaymentType
{
    public class GetAllPaymentTypeQueryHandler : IRequestHandler<GetAllPaymentTypeQuery, ResultViewModel<List<PaymentTypeViewModel>>>
    {
        private readonly IPaymentTypeRepository _repository;
        public GetAllPaymentTypeQueryHandler(IPaymentTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<List<PaymentTypeViewModel>>> Handle(GetAllPaymentTypeQuery request, CancellationToken cancellationToken)
        {
            var payment = await _repository.GetAll(request.Search);

            var model = payment.Select(PaymentTypeViewModel.FromEntity).ToList();

            return ResultViewModel<List<PaymentTypeViewModel>>.Success(model);
        }
    }
}

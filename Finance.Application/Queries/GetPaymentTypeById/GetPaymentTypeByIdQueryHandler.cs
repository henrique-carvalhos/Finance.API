using Finance.Application.Models;
using Finance.Core.Repositories;
using MediatR;

namespace Finance.Application.Queries.GetPaymentTypeById
{
    public class GetPaymentTypeByIdQueryHandler : IRequestHandler<GetPaymentTypeByIdQuery, ResultViewModel<PaymentTypeViewModel>>
    {
        private readonly IPaymentTypeRepository _repository;
        public GetPaymentTypeByIdQueryHandler(IPaymentTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<PaymentTypeViewModel>> Handle(GetPaymentTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var payment = await _repository.GetById(request.Id);

            if (payment is null)
            {
                return ResultViewModel<PaymentTypeViewModel>.Error("Tipo de pagamento não encontrado");
            }

            var model = PaymentTypeViewModel.FromEntity(payment);

            return ResultViewModel<PaymentTypeViewModel>.Success(model);
        }
    }
}

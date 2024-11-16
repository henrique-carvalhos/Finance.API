using Finance.Application.Models;
using Finance.Core.Repositories;
using MediatR;

namespace Finance.Application.Commands.CreatePaymentType
{
    public class CreatePaymentTypeCommandHandler : IRequestHandler<CreatePaymentTypeCommand, ResultViewModel<int>>
    {
        private readonly IPaymentTypeRepository _repository;
        public CreatePaymentTypeCommandHandler(IPaymentTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(CreatePaymentTypeCommand request, CancellationToken cancellationToken)
        {
            var payment = request.ToEntity();

            await _repository.Add(payment);

            return ResultViewModel<int>.Success(payment.Id);
        }
    }
}

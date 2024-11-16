using Finance.Application.Models;
using Finance.Core.Repositories;
using MediatR;

namespace Finance.Application.Commands.UpdatePaymentType
{
    public class UpdatePaymentTypeCommandHandler : IRequestHandler<UpdatePaymentTypeCommand, ResultViewModel>
    {
        private readonly IPaymentTypeRepository _repository;
        public UpdatePaymentTypeCommandHandler(IPaymentTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(UpdatePaymentTypeCommand request, CancellationToken cancellationToken)
        {
            var payment = await _repository.GetById(request.IdPaymentType);

            if(payment is null)
            {
                return ResultViewModel.Error("Tipo de pagamento não existe");
            }

            payment.Update(request.Description);

            await _repository.Update(payment);

            return ResultViewModel.Success();
        }
    }
}

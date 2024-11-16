using Finance.Application.Models;
using Finance.Core.Repositories;
using MediatR;

namespace Finance.Application.Commands.DeletePaymentType
{
    public class DeletePaymentTypeCommandHandler : IRequestHandler<DeletePaymentTypeCommand, ResultViewModel>
    {
        private readonly IPaymentTypeRepository _repository;
        public DeletePaymentTypeCommandHandler(IPaymentTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(DeletePaymentTypeCommand request, CancellationToken cancellationToken)
        {
            var payment = await _repository.GetById(request.Id);

            if (payment is null)
            {
                return ResultViewModel.Error("Tipo de pagamento não existe.");
            }

            payment.SetAsDeleted();
            await _repository.Update(payment);

            return ResultViewModel.Success();
        }
    }
}

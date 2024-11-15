using Finance.Application.Models;
using Finance.Core.Repositories;
using MediatR;

namespace Finance.Application.Commands.DeleteExpenseType
{
    public class DeleteExpenseTypeCommandHandler : IRequestHandler<DeleteExpenseTypeCommand, ResultViewModel>
    {
        private readonly IExpenseTypeRepository _repository;
        public DeleteExpenseTypeCommandHandler(IExpenseTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(DeleteExpenseTypeCommand request, CancellationToken cancellationToken)
        {
            var type = await _repository.GetById(request.Id);

            if (type is null)
            {
                return ResultViewModel.Error("Tipo de despesa não existe.");
            }

            type.SetAsDeleted();
            await _repository.Update(type);

            return ResultViewModel.Success();
        }
    }
}

using Finance.Application.Models;
using Finance.Core.Repositories;
using MediatR;

namespace Finance.Application.Commands.UpdateExpenseType
{
    public class UpdateExpenseTypeCommandHandler : IRequestHandler<UpdateExpenseTypeCommand, ResultViewModel>
    {
        private readonly IExpenseTypeRepository _repository;
        public UpdateExpenseTypeCommandHandler(IExpenseTypeRepository repository)
        {
            _repository = repository;   
        }

        public async Task<ResultViewModel> Handle(UpdateExpenseTypeCommand request, CancellationToken cancellationToken)
        {
            var type = await _repository.GetById(request.Id);

            if (type is null)
            {
                return ResultViewModel.Error("Tipo de despesa não existe.");
            }

            type.Update(request.Name, request.IdExpenseCategory);

            await _repository.Update(type);

            return ResultViewModel.Success();
        }
    }
}

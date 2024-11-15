using Finance.Application.Models;
using Finance.Core.Repositories;
using MediatR;

namespace Finance.Application.Commands.CreateExpenseType
{
    public class CreateExpenseTypeCommandHandler : IRequestHandler<CreateExpenseTypeCommand, ResultViewModel<int>>
    {
        private readonly IExpenseTypeRepository _repository;
        public CreateExpenseTypeCommandHandler(IExpenseTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(CreateExpenseTypeCommand request, CancellationToken cancellationToken)
        {
            var type = request.ToEntity();

            await _repository.Add(type);

            return ResultViewModel<int>.Success(type.Id);
        }
    }
}

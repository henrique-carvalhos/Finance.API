using Finance.Application.Models;
using Finance.Core.Repositories;
using MediatR;

namespace Finance.Application.Commands.CreateExpense
{
    public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, ResultViewModel<int>>
    {
        private readonly IExpenseRepository _repository;
        public CreateExpenseCommandHandler(IExpenseRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = request.ToEntity();

            await _repository.Add(expense);

            return ResultViewModel<int>.Success(expense.Id);
        }
    }
}

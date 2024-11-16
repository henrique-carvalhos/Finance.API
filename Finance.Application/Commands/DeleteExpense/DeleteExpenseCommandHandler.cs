using Finance.Application.Models;
using Finance.Core.Repositories;
using MediatR;

namespace Finance.Application.Commands.DeleteExpense
{
    public class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommand, ResultViewModel>
    {
        private readonly IExpenseRepository _repository;
        public DeleteExpenseCommandHandler(IExpenseRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = await _repository.GetById(request.Id);

            if (expense is null)
            {
                return ResultViewModel.Error("Despesa não encontrada");
            }

            expense.SetAsDeleted();
            await _repository.Update(expense);

            return ResultViewModel.Success();
        }
    }
}

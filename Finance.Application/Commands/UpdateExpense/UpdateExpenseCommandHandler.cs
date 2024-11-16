using Finance.Application.Models;
using Finance.Core.Repositories;
using MediatR;

namespace Finance.Application.Commands.UpdateExpense
{
    internal class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommand, ResultViewModel>
    {
        private readonly IExpenseRepository _repository;
        public UpdateExpenseCommandHandler(IExpenseRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = await _repository.GetById(request.IdExpense);

            if (expense is null)
            {
                return ResultViewModel.Error("Despesa não existe.");
            }

            expense.Update(request.Description, request.Amount, request.DateExpense, request.Card, request.IdUser, request.IdExpenseCategory, request.IdExpenseType, request.IdPaymentType);

            await _repository.Update(expense);

            return ResultViewModel.Success();
        }
    }
}

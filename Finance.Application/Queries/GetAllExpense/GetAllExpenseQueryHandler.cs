using Finance.Application.Models;
using Finance.Core.Repositories;
using MediatR;

namespace Finance.Application.Queries.GetAllExpense
{
    public class GetAllExpenseQueryHandler : IRequestHandler<GetAllExpenseQuery, ResultViewModel<List<ExpenseViewModel>>>
    {
        private readonly IExpenseRepository _repository;
        public GetAllExpenseQueryHandler(IExpenseRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<List<ExpenseViewModel>>> Handle(GetAllExpenseQuery request, CancellationToken cancellationToken)
        {
            var expense = await _repository.GetAll(request.Search);

            var model = expense.Select(ExpenseViewModel.FromEntity).ToList();

            return ResultViewModel<List<ExpenseViewModel>>.Success(model);
        }
    }
}

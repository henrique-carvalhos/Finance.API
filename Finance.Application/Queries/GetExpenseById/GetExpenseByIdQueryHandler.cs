using Finance.Application.Models;
using Finance.Core.Repositories;
using MediatR;

namespace Finance.Application.Queries.GetExpenseById
{
    public class GetExpenseByIdQueryHandler : IRequestHandler<GetExpenseByIdQuery, ResultViewModel<ExpenseViewModel>>
    {
        private readonly IExpenseRepository _repository;
        public GetExpenseByIdQueryHandler(IExpenseRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<ExpenseViewModel>> Handle(GetExpenseByIdQuery request, CancellationToken cancellationToken)
        {
            var expense = await _repository.GetById(request.Id);    

            if(expense is null)
            {
                return ResultViewModel<ExpenseViewModel>.Error("Despensa não encontrada");
            }

            var model = ExpenseViewModel.FromEntity(expense);

            return ResultViewModel<ExpenseViewModel>.Success(model);
        }
    }
}

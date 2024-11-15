using Finance.Application.Models;
using Finance.Core.Repositories;
using MediatR;

namespace Finance.Application.Queries.GetAllExpenseType
{
    public class GetAllExpenseTypeQueryHandler : IRequestHandler<GetAllExpenseTypeQuery, ResultViewModel<List<ExpenseTypeViewModel>>>
    {
        private readonly IExpenseTypeRepository _repository;
        public GetAllExpenseTypeQueryHandler(IExpenseTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<List<ExpenseTypeViewModel>>> Handle(GetAllExpenseTypeQuery request, CancellationToken cancellationToken)
        {
            var type = await _repository.GetAll(request.Search);

            var model = type.Select(ExpenseTypeViewModel.FromEntity).ToList();

            return ResultViewModel<List<ExpenseTypeViewModel>>.Success(model);
        }
    }
}

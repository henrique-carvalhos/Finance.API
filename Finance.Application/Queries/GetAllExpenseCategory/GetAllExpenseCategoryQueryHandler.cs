using Finance.Application.Models;
using Finance.Core.Repositories;
using MediatR;

namespace Finance.Application.Queries.GetAllExpenseCategory
{
    public class GetAllExpenseCategoryQueryHandler : IRequestHandler<GetAllExpenseCategoryQuery, ResultViewModel<List<ExpenseCategoryViewModel>>>
    {
        private readonly IExpenseCategoryRepository _repository;
        public GetAllExpenseCategoryQueryHandler(IExpenseCategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<List<ExpenseCategoryViewModel>>> Handle(GetAllExpenseCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetAll(request.Search);

            var model = category.Select(ExpenseCategoryViewModel.FromEntity).ToList();

            return ResultViewModel<List<ExpenseCategoryViewModel>>.Success(model);
        }
    }
}

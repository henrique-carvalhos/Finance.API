using Finance.Application.Models;
using Finance.Core.Repositories;
using MediatR;

namespace Finance.Application.Queries.GetExpenseCategoryById
{
    public class GetExpenseCategoryByIdQueryHandler : IRequestHandler<GetExpenseCategoryByIdQuery, ResultViewModel<ExpenseCategoryViewModel>>
    {
        private readonly IExpenseCategoryRepository _repository;
        public GetExpenseCategoryByIdQueryHandler(IExpenseCategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<ExpenseCategoryViewModel>> Handle(GetExpenseCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetbyId(request.Id);

            if (category is null)
            {
                return ResultViewModel<ExpenseCategoryViewModel>.Error("Categoria não encontrado");
            }

            var model = ExpenseCategoryViewModel.FromEntity(category);

            return ResultViewModel<ExpenseCategoryViewModel>.Success(model);
        }
    }
}

using Finance.Application.Models;
using Finance.Core.Repositories;
using MediatR;

namespace Finance.Application.Commands.CreateExpenseCategory
{
    public class CreateExpenseCategoryCommandHandler : IRequestHandler<CreateExpenseCategoryCommand, ResultViewModel<int>>
    {
        private readonly IExpenseCategoryRepository _repository;
        public CreateExpenseCategoryCommandHandler(IExpenseCategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(CreateExpenseCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = request.ToEntity();

            await _repository.Add(category);

            return ResultViewModel<int>.Success(category.Id);
        }
    }
}

using Finance.Application.Models;
using Finance.Core.Repositories;
using MediatR;

namespace Finance.Application.Commands.DeleteExpenseCategory
{
    public class DeleteExpenseCategoryCommandHandler : IRequestHandler<DeleteExpenseCategoryCommand, ResultViewModel>
    {
        private readonly IExpenseCategoryRepository _repository;
        public DeleteExpenseCategoryCommandHandler(IExpenseCategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(DeleteExpenseCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetbyId(request.Id);

            if (category is null)
            {
                return ResultViewModel.Error("Categoria de despesa não existe.");
            }

            category.SetAsDeleted();
            await _repository.Update(category);

            return ResultViewModel.Success();
        }
    }
}

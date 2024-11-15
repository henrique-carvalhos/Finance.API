using Finance.Application.Models;
using Finance.Core.Repositories;
using MediatR;

namespace Finance.Application.Commands.UpdateExpenseCatetegory
{
    public class UpdateExpenseCategoryCommandHandler : IRequestHandler<UpdateExpenseCategoryCommand, ResultViewModel>
    {
        private readonly IExpenseCategoryRepository _repository;
        public UpdateExpenseCategoryCommandHandler(IExpenseCategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(UpdateExpenseCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetbyId(request.Id);

            if (category is null)
            {
                return ResultViewModel.Error("Categoria de despesa não existe.");
            }

            category.Update(request.Name);

            await _repository.Update(category);

            return ResultViewModel.Success();
        }
    }
}

using Finance.Application.Models;
using Finance.Core.Repositories;
using MediatR;

namespace Finance.Application.Commands.DeleteIncome
{
    public class DeleteIncomeCommandHandler : IRequestHandler<DeleteIncomeCommand, ResultViewModel>
    {
        private readonly IIncomeRepository _repository;
        public DeleteIncomeCommandHandler(IIncomeRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(DeleteIncomeCommand request, CancellationToken cancellationToken)
        {
            var income = await _repository.GetById(request.Id);

            if (income is null)
            {
                return ResultViewModel.Error("Receita não existe");
            }

            income.SetAsDeleted();
            await _repository.Update(income);

            return ResultViewModel.Success();
        }
    }
}

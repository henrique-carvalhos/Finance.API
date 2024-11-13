using Finance.Application.Models;
using Finance.Core.Repositories;
using MediatR;

namespace Finance.Application.Commands.UpdateIncome
{
    public class UpdateIncomeCommandHanlder : IRequestHandler<UpdateIncomeCommand, ResultViewModel>
    {
        private readonly IIncomeRepository _repository;
        public UpdateIncomeCommandHanlder(IIncomeRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(UpdateIncomeCommand request, CancellationToken cancellationToken)
        {
            var income = await _repository.GetById(request.IdIncome);

            if (income is null)
            {
                return ResultViewModel.Error("Receita não existe.");
            }

            income.Update(request.Description, request.Amount, request.Date, request.IncomeType, request.IdUser);

            await _repository.Update(income);

            return ResultViewModel.Success();
        }
    }
}

using Finance.Application.Models;
using Finance.Core.Repositories;
using MediatR;

namespace Finance.Application.Commands.CreateIncome
{
    public class CreateIncomeCommandHandler : IRequestHandler<CreateIncomeCommand, ResultViewModel<int>>
    {
        private readonly IIncomeRepository _repository;
        public CreateIncomeCommandHandler(IIncomeRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(CreateIncomeCommand request, CancellationToken cancellationToken)
        {
            var income = request.ToEntity();

            await _repository.Add(income);

            return ResultViewModel<int>.Success(income.Id);
        }
    }
}

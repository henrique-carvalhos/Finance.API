using Finance.Application.Models;
using Finance.Core.Repositories;
using MediatR;

namespace Finance.Application.Queries.GetAllIncome
{
    public class GetAllIncomeQueryHandler : IRequestHandler<GetAllIncomeQuery, ResultViewModel<List<IncomeViewModel>>>
    {
        private readonly IIncomeRepository _repository;
        public GetAllIncomeQueryHandler(IIncomeRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<List<IncomeViewModel>>> Handle(GetAllIncomeQuery request, CancellationToken cancellationToken)
        {
            var income = await _repository.GetAll(request.Search);

            var model = income.Select(IncomeViewModel.FromEntity).ToList();

            return ResultViewModel<List<IncomeViewModel>>.Success(model);
        }
    }
}

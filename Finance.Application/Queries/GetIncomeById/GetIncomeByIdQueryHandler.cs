using Finance.Application.Models;
using Finance.Core.Repositories;
using MediatR;

namespace Finance.Application.Queries.GetIncomeById
{
    public class GetIncomeByIdQueryHandler : IRequestHandler<GetIncomeByIdQuery, ResultViewModel<IncomeViewModel>>
    {
        private readonly IIncomeRepository _repository;
        public GetIncomeByIdQueryHandler(IIncomeRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<IncomeViewModel>> Handle(GetIncomeByIdQuery request, CancellationToken cancellationToken)
        {
            var income = await _repository.GetById(request.Id);

            if (income is null)
            {
                return ResultViewModel<IncomeViewModel>.Error("Receita não encontrado");
            }

            var model =  IncomeViewModel.FromEntity(income);

            return ResultViewModel<IncomeViewModel>.Success(model);
        }
    }
}

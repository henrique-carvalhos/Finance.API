using Finance.Application.Models;
using Finance.Core.Repositories;
using MediatR;

namespace Finance.Application.Queries.GetExpenseTypeById
{
    public class GetExpenseTypeByIdQueryHandler : IRequestHandler<GetExpenseTypeByIdQuery, ResultViewModel<ExpenseTypeViewModel>>
    {
        private readonly IExpenseTypeRepository _repository;
        public GetExpenseTypeByIdQueryHandler(IExpenseTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<ExpenseTypeViewModel>> Handle(GetExpenseTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var type = await _repository.GetById(request.Id);

            if (type is null)
            {
                return ResultViewModel<ExpenseTypeViewModel>.Error("Tipo de despesa não encontrado");
            }

            var model = ExpenseTypeViewModel.FromEntity(type);

            return ResultViewModel<ExpenseTypeViewModel>.Success(model);
        }
    }
}

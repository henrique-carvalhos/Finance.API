using Finance.Application.Models;
using MediatR;

namespace Finance.Application.Queries.GetExpenseTypeById
{
    public class GetExpenseTypeByIdQuery : IRequest<ResultViewModel<ExpenseTypeViewModel>>
    {
        public GetExpenseTypeByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

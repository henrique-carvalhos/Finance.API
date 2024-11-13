using Finance.Application.Models;
using MediatR;

namespace Finance.Application.Queries.GetExpenseCategoryById
{
    public class GetExpenseCategoryByIdQuery : IRequest<ResultViewModel<ExpenseCategoryViewModel>>
    {
        public GetExpenseCategoryByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

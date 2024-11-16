using Finance.Application.Models;
using MediatR;

namespace Finance.Application.Queries.GetExpenseById
{
    public class GetExpenseByIdQuery : IRequest<ResultViewModel<ExpenseViewModel>>
    {
        public GetExpenseByIdQuery(int id)
        {
            Id = id;    
        }

        public int Id { get; set; }
    }
}

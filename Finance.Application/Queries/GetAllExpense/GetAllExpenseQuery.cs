using Finance.Application.Models;
using MediatR;

namespace Finance.Application.Queries.GetAllExpense
{
    public class GetAllExpenseQuery : IRequest<ResultViewModel<List<ExpenseViewModel>>>
    {
        public GetAllExpenseQuery(string search)
        {
            Search = search;
        }

        public string Search { get; set; }
    }
}

using Finance.Application.Models;
using MediatR;

namespace Finance.Application.Queries.GetAllExpenseCategory
{
    public class GetAllExpenseCategoryQuery : IRequest<ResultViewModel<List<ExpenseCategoryViewModel>>>
    {
        public GetAllExpenseCategoryQuery(string search)
        {
            Search = search;
        }
        public string Search { get; set; }
    }
}

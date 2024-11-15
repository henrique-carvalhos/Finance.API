using Finance.Application.Models;
using MediatR;

namespace Finance.Application.Queries.GetAllExpenseType
{
    public class GetAllExpenseTypeQuery
    {
        public GetAllExpenseTypeQuery(string search)
        {
            Search = search;
        }
        public string Search { get; set; }
    }
}

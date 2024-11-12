using Finance.Application.Models;
using MediatR;

namespace Finance.Application.Queries.GetAllIncome
{
    public class GetAllIncomeQuery : IRequest<ResultViewModel<List<IncomeViewModel>>>
    {
        public GetAllIncomeQuery(string search)
        {
            Search = search;
        }

        public string Search { get; set; }
    }
}

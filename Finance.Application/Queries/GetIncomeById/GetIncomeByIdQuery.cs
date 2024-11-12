using Finance.Application.Models;
using MediatR;

namespace Finance.Application.Queries.GetIncomeById
{
    public class GetIncomeByIdQuery : IRequest<ResultViewModel<IncomeViewModel>>
    {
        public GetIncomeByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

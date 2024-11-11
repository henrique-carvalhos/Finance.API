using Finance.Application.Models;
using MediatR;

namespace Finance.Application.Queries.GetAllUser
{
    public class GetAllUserQuery : IRequest<ResultViewModel<List<UserViewModel>>>
    {
        public GetAllUserQuery(string search)
        {
            Search = search;
        }
        public string Search { get; set; }
    }
}

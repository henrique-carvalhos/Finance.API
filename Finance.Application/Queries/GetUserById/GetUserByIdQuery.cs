using Finance.Application.Models;
using MediatR;

namespace Finance.Application.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<ResultViewModel<UserViewModel>>
    {
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}

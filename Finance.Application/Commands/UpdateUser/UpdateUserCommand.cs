using Finance.Application.Models;
using MediatR;

namespace Finance.Application.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<ResultViewModel>
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
    }
}

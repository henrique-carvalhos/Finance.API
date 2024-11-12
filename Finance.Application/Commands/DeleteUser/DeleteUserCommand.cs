using Finance.Application.Models;
using MediatR;

namespace Finance.Application.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<ResultViewModel>
    {
        public DeleteUserCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}

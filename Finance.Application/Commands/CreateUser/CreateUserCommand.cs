using Finance.Application.Models;
using Finance.Core.Entities;
using MediatR;

namespace Finance.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<ResultViewModel<int>>
    {
        public string Name { get; set; }

        public User ToEntity()
            => new(Name);
    }
}

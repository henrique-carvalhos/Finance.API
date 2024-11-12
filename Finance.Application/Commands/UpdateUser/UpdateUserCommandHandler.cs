using Finance.Application.Models;
using Finance.Core.Repositories;
using MediatR;

namespace Finance.Application.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ResultViewModel>
    {
        private readonly IUserRepository _repository;
        public UpdateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetbyId(request.IdUser);

            if (user is null)
            {
                return ResultViewModel.Error("Usuário não existe.");
            }

            user.Update(request.Name);

            await _repository.Update(user);

            return ResultViewModel.Success();
        }
    }
}
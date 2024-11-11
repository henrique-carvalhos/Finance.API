using Finance.Application.Models;
using Finance.Core.Repositories;
using MediatR;

namespace Finance.Application.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ResultViewModel<UserViewModel>>
    {
        private readonly IUserRepository _repository;
        public GetUserByIdQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<UserViewModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetbyId(request.Id);

            if(user is null)
            {
                return ResultViewModel<UserViewModel>.Error("Usuário não encontrado");
            }

            var model = UserViewModel.FromEntity(user);

            return ResultViewModel<UserViewModel>.Success(model);
        }
    }
}

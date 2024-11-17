using Finance.Application.Models;
using Finance.Infrastructure.Persistence;
using MediatR;

namespace Finance.Application.Commands.CreateIncome
{
    internal class ValidateCreateIncomeCommandBehavior :
        IPipelineBehavior<CreateIncomeCommand, ResultViewModel<int>>
    {
        private readonly FinanceDbContext _context;
        public ValidateCreateIncomeCommandBehavior(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<int>> Handle(CreateIncomeCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var userExists = _context.Users.Any(u => u.Id == request.IdUser);

            if (!userExists)
            {
                return ResultViewModel<int>.Error("Usuário inválido");
            }

            return await next();
        }
    }
}

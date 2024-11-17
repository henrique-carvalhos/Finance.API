using Finance.Application.Models;
using Finance.Infrastructure.Persistence;
using MediatR;

namespace Finance.Application.Commands.CreateExpenseType
{
    public class ValidateCreateExpenseTypeCommandBehavior :
        IPipelineBehavior<CreateExpenseTypeCommand, ResultViewModel<int>>
    {
        private readonly FinanceDbContext _context;
        public ValidateCreateExpenseTypeCommandBehavior(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<int>> Handle(CreateExpenseTypeCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var expenseCategoryExists = _context.ExpensesCategories.Any(e => e.Id == request.IdExpenseCategory);

            if (!expenseCategoryExists)
            {
                return ResultViewModel<int>.Error("Categoria de despesa inválida");
            }

            return await next();
        }
    }
}

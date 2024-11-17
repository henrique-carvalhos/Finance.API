using Finance.Application.Models;
using Finance.Infrastructure.Persistence;
using MediatR;

namespace Finance.Application.Commands.CreateExpense
{
    public class ValidateCreateExpenseCommandBehavior :
        IPipelineBehavior<CreateExpenseCommand, ResultViewModel<int>>
    {
        private readonly FinanceDbContext _context;
        public ValidateCreateExpenseCommandBehavior(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<int>> Handle(CreateExpenseCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var userExists = _context.Users.Any(e => e.Id == request.IdUser);
            var expenseCategoryExists = _context.ExpensesCategories.Any(e => e.Id == request.IdExpenseCategory);
            var paymentTypeExists = _context.PaymentTypes.Any(e => e.Id == request.IdPaymentType);
            var expenseTypeExists = _context.ExpensesTypes.Any(e => e.Id == request.IdExpenseType);

            if (!userExists || !expenseCategoryExists || !paymentTypeExists || !expenseTypeExists)
            {
                return ResultViewModel<int>.Error("Usuário, categoria/tipo despesa ou tipo de pagamento são inválidos");
            }

            return await next();
        }
    }
}

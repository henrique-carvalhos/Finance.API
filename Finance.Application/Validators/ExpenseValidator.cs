using Finance.Application.Commands.CreateExpense;
using FluentValidation;

namespace Finance.Application.Validators
{
    public class ExpenseValidator : AbstractValidator<CreateExpenseCommand>
    {
        public ExpenseValidator()
        {
            RuleFor(p => p.Description)
                .NotEmpty()
                .WithMessage("Descrição não pode ser vazia")
                .MaximumLength(100)
                .WithMessage("Tamanho máximo é de 100 caracteres");

            RuleFor(p => p.Amount)
                .NotEmpty()
                .WithMessage("Valor deve ser preenchido");

            RuleFor(p => p.DateExpense)
                .NotEmpty()
                .WithMessage("Data deve ser preenchido");
        }
    }
}

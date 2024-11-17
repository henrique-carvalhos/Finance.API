using Finance.Application.Commands.CreateExpenseCategory;
using FluentValidation;

namespace Finance.Application.Validators
{
    public class ExpenseCategoryValidator : AbstractValidator<CreateExpenseCategoryCommand>
    {
        public ExpenseCategoryValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("Nome não pode ser vazia")
                .MaximumLength(50)
                .WithMessage("Tamanho máximo é de 50 caracteres");
        }
    }
}

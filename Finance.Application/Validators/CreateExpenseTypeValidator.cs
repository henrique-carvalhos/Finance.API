using Finance.Application.Commands.CreateExpenseType;
using FluentValidation;

namespace Finance.Application.Validators
{
    public class CreateExpenseTypeValidator : AbstractValidator<CreateExpenseTypeCommand>
    {
        public CreateExpenseTypeValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("Nome não pode ser vazia")
                .MaximumLength(50)
                .WithMessage("Tamanho máximo é de 50 caracteres");
        }
    }
}

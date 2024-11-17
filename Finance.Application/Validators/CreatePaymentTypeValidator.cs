using Finance.Application.Commands.CreatePaymentType;
using FluentValidation;

namespace Finance.Application.Validators
{
    public class CreatePaymentTypeValidator : AbstractValidator<CreatePaymentTypeCommand>
    {
        public CreatePaymentTypeValidator()
        {
            RuleFor(p => p.Description)
                .NotEmpty()
                .WithMessage("Descrição não pode ser vazia")
                .MaximumLength(50)
                .WithMessage("Tamanho máximo é de 50 caracteres");
        }
    }
}

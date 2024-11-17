using Finance.Application.Commands.CreateIncome;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Finance.Application.Validators
{
    internal class CreateIncomeValidator : AbstractValidator<CreateIncomeCommand>
    {
        public CreateIncomeValidator()
        {
            RuleFor(p => p.Description)
                .NotEmpty()
                .WithMessage("Descrição não pode ser vazia")
                .MaximumLength(100)
                .WithMessage("Tamanho máximo é de 100 caracteres");

            RuleFor(p => p.Amount)
                .NotEmpty()
                .WithMessage("Valor deve ser preenchido");

            RuleFor(p => p.Date)
                .NotEmpty()
                .WithMessage("Data deve ser preenchido");

            RuleFor(p => p.IncomeType)
                .NotEmpty()
                .WithMessage("Tipo de receita deve ser preenchido");

            RuleFor(p => p.IdUser)
                .NotEmpty()
                .WithMessage("Id do usuário não foi preenchido, e é necessário na criação");
        }
    }
}

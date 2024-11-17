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

            RuleFor(p => p.Card)
                .NotEmpty()
                .WithMessage("Informe um cartão valido");

            RuleFor(p => p.IdUser)
                .NotEmpty()
                .WithMessage("Id do usuário não foi preenchido, e é necessário na criação");

            RuleFor(p => p.IdExpenseType)
                .NotEmpty()
                .WithMessage("Id do tipo de despesa não foi preenchido, e é necessário na criação");
            
            RuleFor(p => p.IdExpenseCategory)
                .NotEmpty()
                .WithMessage("Id da categoria de despesa não foi preenchido, e é necessário na criação");
            
            RuleFor(p => p.IdPaymentType)
                .NotEmpty()
                .WithMessage("Id do tipo de pagamento não foi preenchido, e é necessário na criação");
        }
    }
}

using Finance.Application.Models;
using Finance.Core.Entities;
using Finance.Core.Enums;
using MediatR;

namespace Finance.Application.Commands.CreateExpense
{
    public class CreateExpenseCommand : IRequest<ResultViewModel<int>>
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateExpense { get; set; }
        public Card Card { get; set; }
        public int IdUser { get; set; }
        public int IdExpenseCategory { get; set; }
        public int IdExpenseType { get; set; }
        public int IdPaymentType { get; set; }

        public Expense ToEntity()
            => new(Description, Amount, DateExpense, Card, IdUser, IdExpenseCategory, IdExpenseType, IdPaymentType);
    }
}

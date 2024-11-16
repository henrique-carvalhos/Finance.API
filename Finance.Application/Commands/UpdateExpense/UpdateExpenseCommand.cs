using Finance.Application.Models;
using Finance.Core.Enums;
using MediatR;

namespace Finance.Application.Commands.UpdateExpense
{
    public class UpdateExpenseCommand : IRequest<ResultViewModel>
    {
        public int IdExpense { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateExpense { get; set; }
        public Card Card { get; set; }

        public int IdUser { get; set; }
        public int IdExpenseCategory { get; set; }
        public int IdExpenseType { get; set; }
        public int IdPaymentType { get; set; }
    }
}

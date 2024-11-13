using Finance.Application.Models;
using Finance.Core.Enums;
using MediatR;

namespace Finance.Application.Commands.UpdateIncome
{
    public class UpdateIncomeCommand : IRequest<ResultViewModel>
    {
        public int IdIncome { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public IncomeType IncomeType { get; set; }
        public int IdUser { get; set; }
    }
}

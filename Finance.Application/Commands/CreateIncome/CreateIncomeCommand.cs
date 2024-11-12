using Finance.Application.Models;
using Finance.Core.Entities;
using Finance.Core.Enums;
using MediatR;

namespace Finance.Application.Commands.CreateIncome
{
    public class CreateIncomeCommand : IRequest<ResultViewModel<int>>
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public IncomeType IncomeType { get; set; }
        public int IdUser { get; set; }

        public Income ToEntity()
           => new(Description, Amount, Date, IncomeType, IdUser);
    }
}

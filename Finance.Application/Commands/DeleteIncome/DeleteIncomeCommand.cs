using Finance.Application.Models;
using MediatR;

namespace Finance.Application.Commands.DeleteIncome
{
    public class DeleteIncomeCommand : IRequest<ResultViewModel>
    {
        public DeleteIncomeCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

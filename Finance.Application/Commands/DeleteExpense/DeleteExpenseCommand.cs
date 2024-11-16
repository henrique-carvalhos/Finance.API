using Finance.Application.Models;
using MediatR;

namespace Finance.Application.Commands.DeleteExpense
{
    public class DeleteExpenseCommand : IRequest<ResultViewModel>
    {
        public DeleteExpenseCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

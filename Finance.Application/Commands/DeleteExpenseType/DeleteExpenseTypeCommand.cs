using Finance.Application.Models;
using MediatR;

namespace Finance.Application.Commands.DeleteExpenseType
{
    public class DeleteExpenseTypeCommand : IRequest<ResultViewModel>
    {
        public DeleteExpenseTypeCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

using Finance.Application.Models;
using MediatR;

namespace Finance.Application.Commands.DeleteExpenseCategory
{
    public class DeleteExpenseCategoryCommand : IRequest<ResultViewModel>
    {
        public DeleteExpenseCategoryCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}

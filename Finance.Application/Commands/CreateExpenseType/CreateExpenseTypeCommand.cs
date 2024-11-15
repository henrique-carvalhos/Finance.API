using Finance.Application.Models;
using Finance.Core.Entities;
using MediatR;

namespace Finance.Application.Commands.CreateExpenseType
{
    public class CreateExpenseTypeCommand : IRequest<ResultViewModel<int>>
    {
        public string Name { get; set; }
        public int IdExpenseCategory { get; set; }

        public ExpenseType ToEntity()
            => new (Name, IdExpenseCategory);
    }
}

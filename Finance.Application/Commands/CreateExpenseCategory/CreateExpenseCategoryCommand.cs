using Finance.Application.Models;
using Finance.Core.Entities;
using MediatR;

namespace Finance.Application.Commands.CreateExpenseCategory
{
    public class CreateExpenseCategoryCommand : IRequest<ResultViewModel<int>>
    {
        public string Name { get; set; }

        public ExpenseCategory ToEntity()
            => new(Name);
    }
}

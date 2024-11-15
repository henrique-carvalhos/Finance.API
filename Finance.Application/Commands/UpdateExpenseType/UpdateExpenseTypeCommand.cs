using Finance.Application.Models;
using MediatR;

namespace Finance.Application.Commands.UpdateExpenseType
{
    public class UpdateExpenseTypeCommand : IRequest<ResultViewModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdExpenseCategory { get; set; }
    }
}

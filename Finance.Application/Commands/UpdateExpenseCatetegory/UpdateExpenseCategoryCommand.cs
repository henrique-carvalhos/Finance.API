using Finance.Application.Models;
using MediatR;

namespace Finance.Application.Commands.UpdateExpenseCatetegory
{
    public class UpdateExpenseCategoryCommand : IRequest<ResultViewModel>
    {

        public int Id { get; set; }
        public string Name { get; set; }

    }
}

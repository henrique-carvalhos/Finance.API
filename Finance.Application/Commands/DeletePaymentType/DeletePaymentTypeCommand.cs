using Finance.Application.Models;
using MediatR;

namespace Finance.Application.Commands.DeletePaymentType
{
    public class DeletePaymentTypeCommand : IRequest<ResultViewModel>
    {
        public DeletePaymentTypeCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

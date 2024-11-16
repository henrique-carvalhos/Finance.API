using Finance.Application.Models;
using MediatR;

namespace Finance.Application.Commands.UpdatePaymentType
{
    public class UpdatePaymentTypeCommand : IRequest<ResultViewModel>
    {
        public int IdPaymentType { get; set; }
        public string Description { get; set; }
    }
}

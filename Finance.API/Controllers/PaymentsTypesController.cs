using Finance.Application.Commands.CreatePaymentType;
using Finance.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Finance.API.Controllers
{
    [ApiController]
    [Route("api/paymentType")]
    public class PaymentsTypesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly FinanceDbContext _context;
        public PaymentsTypesController(IMediator mediator, FinanceDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _context.PaymentTypes
                .SingleOrDefault(x => x.Id == id);

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Post(CreatePaymentTypeCommand command)
        {
            var result = await _mediator.Send(command);
            
            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }
    }
}

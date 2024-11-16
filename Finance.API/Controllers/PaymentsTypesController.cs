using Finance.Application.Commands.CreatePaymentType;
using Finance.Application.Queries.GetAllPaymentType;
using Finance.Application.Queries.GetPaymentTypeById;
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
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetPaymentTypeByIdQuery(id);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string search = "")
        {
            var query = new GetAllPaymentTypeQuery(search);

            var result = await _mediator.Send(query);

            if (result is null)
            {
                return NotFound();
            }

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

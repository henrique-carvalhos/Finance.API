using Finance.Application.Commands.CreatePaymentType;
using Finance.Application.Commands.DeletePaymentType;
using Finance.Application.Commands.UpdatePaymentType;
using Finance.Application.Queries.GetAllPaymentType;
using Finance.Application.Queries.GetPaymentTypeById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Finance.API.Controllers
{
    [ApiController]
    [Route("api/paymentsTypes")]
    public class PaymentsTypesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PaymentsTypesController(IMediator mediator)
        {
            _mediator = mediator;
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

        [HttpPut]
        public async Task<IActionResult> Put(int id,UpdatePaymentTypeCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeletePaymentTypeCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
;
            return NoContent();
        }
    }
}

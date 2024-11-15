using Finance.Application.Commands.CreateExpenseType;
using Finance.Application.Commands.DeleteExpenseType;
using Finance.Application.Commands.UpdateExpenseType;
using Finance.Application.Queries.GetAllExpenseType;
using Finance.Application.Queries.GetExpenseTypeById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Finance.API.Controllers
{
    [ApiController]
    [Route("api/expensesTypes")]
    public class ExpensesTypesControllers : ControllerBase
    {
        private readonly IMediator _mediator;
        public ExpensesTypesControllers(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetExpenseTypeByIdQuery(id);

            var result = await _mediator.Send(query);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string search = "")
        {
            var query = new GetAllExpenseTypeQuery(search);

            var result = await _mediator.Send(query);

            return Ok(result); 
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateExpenseTypeCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new {id = result.Data } ,command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteExpenseTypeCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return  NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, UpdateExpenseTypeCommand command)
        {
            var result = _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(Request.Message);
            }

            return NoContent();
        }
    }
}

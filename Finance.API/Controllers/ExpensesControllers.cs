using Finance.Application.Commands.CreateExpense;
using Finance.Application.Commands.CreateExpenseCategory;
using Finance.Application.Commands.DeleteExpense;
using Finance.Application.Commands.UpdateExpense;
using Finance.Application.Models;
using Finance.Application.Queries.GetAllExpense;
using Finance.Application.Queries.GetExpenseById;
using Finance.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Finance.API.Controllers
{
    [ApiController]
    [Route("api/expenses")]
    public class ExpensesControllers : ControllerBase
    {
        private readonly IMediator _mediator;
        public ExpensesControllers(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var expense = new GetExpenseByIdQuery(id);

            var result = await _mediator.Send(expense);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string search = "")
        {
            var expense = new GetAllExpenseQuery(search);

            var result = await _mediator.Send(expense);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateExpenseCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id =  result.Data}, command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteExpenseCommand(id));

            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, UpdateExpenseCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}

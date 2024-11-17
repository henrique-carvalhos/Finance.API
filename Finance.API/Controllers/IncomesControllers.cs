using Finance.Application.Commands.CreateIncome;
using Finance.Application.Commands.DeleteIncome;
using Finance.Application.Commands.UpdateIncome;
using Finance.Application.Queries.GetAllIncome;
using Finance.Application.Queries.GetIncomeById;
using Finance.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Finance.API.Controllers
{
    [ApiController]
    [Route("api/incomes")]
    public class IncomesControllers : ControllerBase
    {
        private readonly IMediator _mediator;
        public IncomesControllers(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetIncomeByIdQuery(id);

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
            var query = new GetAllIncomeQuery(search);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateIncomeCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return CreatedAtAction(nameof(GetById), new {id = result.Data}, command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteIncomeCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
;
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, UpdateIncomeCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpGet("IncomeTypes")]
        public IActionResult GetIncomeTypes()
        {
            var incomeTypes = Enum.GetValues(typeof(IncomeType))
                                  .Cast<IncomeType>()
                                  .Select(e => new { Id = (int)e, Name = e.ToString() })
                                  .ToList();

            return Ok(incomeTypes);
        }
    }
}

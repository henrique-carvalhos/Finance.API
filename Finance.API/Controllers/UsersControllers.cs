using Finance.Application.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Finance.Application.Queries.GetAllUser;
using Finance.Application.Commands.CreateUser;
using Finance.Application.Commands.UpdateUser;
using Finance.Application.Commands.DeleteUser;

namespace Finance.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersControllers : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersControllers(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var query = new GetUserByIdQuery(id);

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
            var query = new GetAllUserQuery(search);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUserCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteUserCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, UpdateUserCommand command)
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

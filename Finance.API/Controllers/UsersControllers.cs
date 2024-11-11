using Finance.Application.Models;
using Finance.Application.Queries.GetUserById;
using Finance.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Finance.Core.Entities;

namespace Finance.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersControllers : ControllerBase
    {
        private readonly FinanceDbContext _context;
        private readonly IMediator _mediator;
        public UsersControllers(FinanceDbContext context, IMediator mediator)
        {
            _context = context;
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
        public IActionResult Get(string search = "")
        {
            var users = _context.Users
                .Include(i => i.Incomes)
                .Include(e => e.Expenses)
                .Where(u => search == "" || u.Name.Contains(search))
                .ToList();

            var model = users.Select(UserViewModel.FromEntity).ToList();

            return Ok(model);
        }

        [HttpPost]
        public IActionResult Post(CreateUserInputModel model)
        {
            var user = new User(model.Name);

            _context.Users.Add(user);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.SingleOrDefault(p => p.Id == id);

            if (user is null)
            {
                return NotFound();
            }

            user.SetAsDeleted();
            _context.Users.Update(user);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut]
        public IActionResult Put(int id, UpdateUserInputModel model)
        {
            var user = _context.Users.SingleOrDefault(p => p.Id == id);

            if (user is null)
            {
                return NotFound();
            }

            user.Update(model.Name);

            _context.Users.Update(user);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

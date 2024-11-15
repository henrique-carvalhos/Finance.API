using Finance.Application.Commands.DeleteExpenseCategory;
using Finance.Application.Commands.UpdateExpenseCatetegory;
using Finance.Application.Models;
using Finance.Application.Queries.GetAllExpenseCategory;
using Finance.Application.Queries.GetExpenseCategoryById;
using Finance.Core.Entities;
using Finance.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Finance.API.Controllers
{
    [ApiController]
    [Route("api/expensesCategories")]
    public class ExpensesCategoriesControllers : ControllerBase
    {
        private readonly FinanceDbContext _context;
        private readonly IMediator _mediator;
        public ExpensesCategoriesControllers(FinanceDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetExpenseCategoryByIdQuery(id);

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
            var query = new GetAllExpenseCategoryQuery(search);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(CreateExpenseCategoryInputModel model)
        {
            var category = new ExpenseCategory(model.Name);

            _context.ExpensesCategories.Add(category);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteExpenseCategoryCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, UpdateExpenseCategoryCommand command)
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

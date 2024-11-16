using Finance.Application.Commands.CreateExpense;
using Finance.Application.Commands.CreateExpenseCategory;
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
        private readonly FinanceDbContext _context;
        private readonly IMediator _mediator;
        public ExpensesControllers(FinanceDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var expense = new GetExpenseByIdQuery(id);

            var result = await _mediator.Send(expense);

            if (expense is null)
            {
                return NotFound();
            }

            return Ok(expense);
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
            var expense = _context.Expenses.SingleOrDefault(p => p.Id == id);

            if (expense is null)
            {
                return NotFound();
            }

            expense.SetAsDeleted();
            _context.Expenses.Update(expense);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, UpdateExpenseInputModel model)
        {
            var expense = _context.Expenses.SingleOrDefault(p => p.Id == id);

            if (expense is null)
            {
                return NotFound();
            }

            expense.Update(model.Description, model.Amount, model.DateExpense, model.Card, model.IdUser, model.IdExpenseCategory, model.IdExpenseType, model.IdPaymentType);

            _context.Expenses.Update(expense);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

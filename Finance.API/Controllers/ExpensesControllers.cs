using Finance.Application.Models;
using Finance.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Finance.API.Controllers
{
    [ApiController]
    [Route("api/expenses")]
    public class ExpensesControllers : ControllerBase
    {
        private readonly FinanceDbContext _context;
        public ExpensesControllers(FinanceDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var expense = _context.Expenses
                .Include(u => u.User)
                .Include(e => e.ExpenseCategory)
                .Include(e => e.ExpenseType)
                .SingleOrDefault(x => x.Id == id);

            if (expense is null)
            {
                return NotFound();
            }

            var model = ExpenseViewModel.FromEntity(expense);

            return Ok(model);
        }

        [HttpGet]
        public IActionResult Get(string search = "")
        {
            var expenses = _context.Expenses
                .Include(u => u.User)
                .Include(e => e.ExpenseCategory)
                .Include(e => e.ExpenseType)
                .Where(u => !u.IsDeleted &&(search == "" || u.Description.Contains(search)))
                .ToList();

            var model = expenses.Select(ExpenseViewModel.FromEntity).ToList();

            return Ok(model);
        }

        [HttpPost]
        public IActionResult Post(CreateExpenseInputModel model)
        {
            var expense = model.ToEntity();

            _context.Expenses.Add(expense);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
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
        public IActionResult Put(int id, UpdateExpenseInputModel model)
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

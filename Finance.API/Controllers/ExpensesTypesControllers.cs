using Finance.Application.Models;
using Finance.Core.Entities;
using Finance.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Finance.API.Controllers
{
    [ApiController]
    [Route("api/expensesTypes")]
    public class ExpensesTypesControllers : ControllerBase
    {
        private readonly FinanceDbContext _context;
        public ExpensesTypesControllers(FinanceDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var type = _context.ExpensesTypes
                .SingleOrDefault(x => x.Id == id);

            if (type is null)
            {
                return NotFound();
            }

            return Ok(type);
        }

        [HttpGet]
        public IActionResult Get(string search = "")
        {
            var type = _context.ExpensesTypes
                .Where(u => search == "" || u.Name.Contains(search))
                .ToList();

            return Ok(type);
        }

        [HttpPost]
        public IActionResult Post(CreateExpenseTypeInputModel model)
        {
            var type = new ExpenseType(model.Name, model.IdExpenseCategory);

            _context.ExpensesTypes.Add(type);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var type = _context.ExpensesTypes.SingleOrDefault(p => p.Id == id);

            if (type is null)
            {
                return NotFound();
            }

            type.SetAsDeleted();
            _context.ExpensesTypes.Update(type);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut]
        public IActionResult Put(int id, UpdateExpenseTypeInputModel model)
        {
            var type = _context.ExpensesTypes.SingleOrDefault(p => p.Id == id);

            if (type is null)
            {
                return NotFound();
            }

            type.Update(model.Name, model.IdExpenseCategory);

            _context.ExpensesTypes.Update(type);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

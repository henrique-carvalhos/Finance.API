using Finance.Application.Models;
using Finance.Core.Entities;
using Finance.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Finance.API.Controllers
{
    [ApiController]
    [Route("api/expensesCategories")]
    public class ExpensesCategoriesControllers : ControllerBase
    {
        private readonly FinanceDbContext _context;
        public ExpensesCategoriesControllers(FinanceDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _context.ExpensesCategories
                .SingleOrDefault(x => x.Id == id);

            if (category is null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpGet]
        public IActionResult Get(string search = "")
        {
            var category = _context.ExpensesCategories
                .Where(u => search == "" || u.Name.Contains(search))
                .ToList();

            return Ok(category);
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
        public IActionResult Delete(int id)
        {
            var category = _context.ExpensesCategories.SingleOrDefault(p => p.Id == id);

            if (category is null)
            {
                return NotFound();
            }

            category.SetAsDeleted();
            _context.ExpensesCategories.Update(category);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut]
        public IActionResult Put(int id, UpdateExpenseCategoryInputModel model)
        {
            var category = _context.ExpensesCategories.SingleOrDefault(p => p.Id == id);

            if (category is null)
            {
                return NotFound();
            }

            category.Update(model.Name);

            _context.ExpensesCategories.Update(category);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

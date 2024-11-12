using Finance.Application.Models;
using Finance.Application.Queries.GetIncomeById;
using Finance.Application.Queries.GetUserById;
using Finance.Core.Entities;
using Finance.Core.Enums;
using Finance.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Finance.API.Controllers
{
    [ApiController]
    [Route("api/incomes")]
    public class IncomesControllers : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly FinanceDbContext _context;
        public IncomesControllers(FinanceDbContext context, IMediator mediator)
        {
            _context = context;
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
        public IActionResult Get(string search = "")
        {
            var incomes = _context.Incomes
                .Include(i => i.User)
                .Where(u => search == "" || u.Description.Contains(search))
                .ToList();

            var model = incomes.Select(IncomeViewModel.FromEntity).ToList();

            return Ok(model);
        }

        [HttpPost]
        public IActionResult Post(CreateIncomeInputModel model)
        {
            var income = new Income(model.Description, model.Amount, model.Date, model.IncomeType, model.IdUser);

            _context.Incomes.Add(income);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var income = _context.Incomes.SingleOrDefault(p => p.Id == id);

            if (income is null)
            {
                return NotFound();
            }

            income.SetAsDeleted();
            _context.Incomes.Update(income);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut]
        public IActionResult Put(int id, UpdateIncomeInputModel model)
        {
            var income = _context.Incomes.SingleOrDefault(p => p.Id == id);

            if (income is null)
            {
                return NotFound();
            }

            income.Update(model.Description, model.Amount, model.Date, model.IncomeType, model.IdUser);

            _context.Incomes.Update(income);
            _context.SaveChanges();

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

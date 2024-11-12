﻿using Finance.Application.Commands.CreateIncome;
using Finance.Application.Models;
using Finance.Application.Queries.GetAllIncome;
using Finance.Application.Queries.GetAllUser;
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

            return CreatedAtAction(nameof(GetById), new {id = result.Data}, command);
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

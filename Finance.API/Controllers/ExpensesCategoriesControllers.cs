﻿using Finance.Application.Models;
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

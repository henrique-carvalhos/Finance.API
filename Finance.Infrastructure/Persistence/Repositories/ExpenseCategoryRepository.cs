﻿using Finance.Core.Entities;
using Finance.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infrastructure.Persistence.Repositories
{
    public class ExpenseCategoryRepository : IExpenseCategoryRepository
    {
        private readonly FinanceDbContext _context;
        public ExpenseCategoryRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(ExpenseCategory expenseCategory)
        {
            await _context.ExpensesCategories.AddAsync(expenseCategory);

            return expenseCategory.Id;
        }

        public async Task<List<ExpenseCategory>> GetAll(string search)
        {
            var expenseCategory = await _context.ExpensesCategories
                .Where(u => search == "" || u.Name.Contains(search))
                .ToListAsync();

            return expenseCategory;
        }

        public async Task<ExpenseCategory?> GetbyId(int id)
        {
            return await _context.ExpensesCategories
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(ExpenseCategory expenseCategory)
        {
            _context.Update(expenseCategory);
            await _context.SaveChangesAsync();
        }
    }
}
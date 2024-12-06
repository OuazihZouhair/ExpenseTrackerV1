using Expense_Tracker.Data;
using Expense_Tracker.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly DataContext _context;

        public ExpenseController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Expense>>> GetAllExpenses()
        {
            var expenses = await _context.Expenses
                .Include(e => e.User)
                .ToListAsync();

            return Ok(expenses);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Expense>> GetExpense(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense is null)
                return NotFound("Expense not found.");

            return Ok(expense);
        }


        [HttpPost]
        public async Task<ActionResult<List<Expense>>> AddExpense(Expense e, int userId)
        {

            var user = await _context.User.FindAsync(userId);
            // Check if the user exists
            if (user == null)
            {
                return NotFound($"User with ID {userId} does not exist.");
            }

            // Set the UserId and User for the Expense
            e.UserId = userId;
            e.User = user;

            _context.Expenses.Add(e);
            await _context.SaveChangesAsync();

            //return Ok(await _context.Expenses.ToListAsync());
            return Ok(await _context.Expenses.Include(exp => exp.User).ToListAsync());
        }


        [HttpPut]
        public async Task<ActionResult<List<Expense>>> UpdateExpense(Expense upE)
        {
            var expense = await _context.Expenses.FindAsync(upE.Id);
            if (expense is null)
                return NotFound("Expense not found.");

            expense.category = upE.category;
            expense.amount = upE.amount;
            expense.date = upE.date;
            //expense.userId = upE.userId;

            await _context.SaveChangesAsync();

            return Ok(await _context.Expenses.ToListAsync());
        }


        [HttpDelete]
        public async Task<ActionResult<List<Expense>>> DeleteExpense(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense is null)
                return NotFound("Expense not found.");

            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();

            return Ok(await _context.Expenses.ToListAsync());
        }
    }
}

using Expense_Tracker.Data;
using Expense_Tracker.Entities;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> _userManager;

        public ExpenseController(DataContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<Expense>>> GetAllExpenses()
        {
            // Get the currently logged-in user's Id
            var userId = _userManager.GetUserId(User);

            // Retrieve expenses for the logged-in user
            var expenses = await _context.Expenses
                .Where(e => e.UserId == userId)
                .ToListAsync();

            return Ok(expenses);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Expense>> GetExpense(int id)
        {
            // Get the logged-in user's Id
            var userId = _userManager.GetUserId(User);

            // Find the expense bu Id and ensure that it belogns the the right user

            var expense = await _context.Expenses.FirstOrDefaultAsync(e => e.Id == id && e.UserId == userId);

            if (expense is null)
                return NotFound("Expense not found.");

            return Ok(expense);
        }


        [HttpPost]
        public async Task<ActionResult<List<Expense>>> AddExpense(Expense e)
        {
            // Get the logged-in user's Id
            var userId = _userManager.GetUserId(User);

            // Associate the new expense with the logged-in user 
            e.UserId = userId;

            _context.Expenses.Add(e);
            await _context.SaveChangesAsync();

            //return Ok(await _context.Expenses.ToListAsync());
            return Ok(await _context.Expenses
                .Where(e => e.UserId == userId)
                .ToListAsync());
        }


        [HttpPut]
        public async Task<ActionResult<List<Expense>>> UpdateExpense(Expense upE)
        {
            // Get the logged-in user's Id
            var userId = _userManager.GetUserId(User);

            // Find the existing expense by Id and ensure it belongs to the logged-in user
            var expense = await _context.Expenses
                .FirstOrDefaultAsync(e => e.Id == upE.Id && e.UserId == userId);

            if (expense is null)
                return NotFound("Expense not found.");

            expense.amount = upE.amount;
            expense.description = upE.description;
            expense.category = upE.category;
            expense.date = upE.date;

            await _context.SaveChangesAsync();

            return Ok(await _context.Expenses
                .Where(e => e.UserId == userId)
                .ToListAsync());
        }


        [HttpDelete]
        public async Task<ActionResult<List<Expense>>> DeleteExpense(int id)
        {
            var userId = _userManager.GetUserId(User);

            var expense = await _context.Expenses
                .FirstOrDefaultAsync( e => e.Id == id && e.UserId == userId);

            if (expense is null)
                return NotFound("Expense not found.");

            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();

            return Ok(await _context.Expenses
                .Where(e => e.UserId == userId)
                .ToListAsync());
        }
    }
}

using Expense_Tracker.Data;
using Expense_Tracker.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public BudgetController(DataContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<Budget>>> GetAllBudgets()
        {
            // Get the currently logged-in user's Id
            var userId = _userManager.GetUserId(User);

            // Retrieve budgets for the logged-in user
            var budgets = await _context.Budgets
                .Where(b => b.UserId == userId)
                .ToListAsync();

            return Ok(budgets);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Budget>> GetBugdet(int id)
        {
            // Get the logged-in user's Id
            var userId = _userManager.GetUserId(User);

            // Find the expense bu Id and ensure that it belogns the the right user

            var budget = await _context.Budgets
                .FirstOrDefaultAsync(b => b.Id == id && b.UserId == userId);

            if (budget is null)
                return NotFound("Budget Not Found");


            return Ok(budget);
        }


        [HttpPost]
        public async Task<ActionResult<List<Budget>>> AddBudget(Budget b)
        {
            // Get the logged-in user's Id
            var userId = _userManager.GetUserId(User);

            // Associate the new expense with the logged-in user 
            b.UserId = userId;

            _context.Budgets.Add(b);
            await _context.SaveChangesAsync();

            //return Ok(await _context.Expenses.ToListAsync());
            return Ok(await _context.Budgets
                .Where(b => b.UserId == userId)
                .ToListAsync());
        }


        [HttpPut]
        public async Task<ActionResult<List<Budget>>> UpdateBudget(Budget upB)
        {
            // Get the logged-in user's Id
            var userId = _userManager.GetUserId(User);

            // Find the existing expense by Id and ensure it belongs to the logged-in user
            var budget = await _context.Budgets
                .FirstOrDefaultAsync(b => b.Id == upB.Id && b.UserId == userId);

            if (budget is null)
                return NotFound("Budget not found.");

            budget.amount = upB.amount;
            budget.createdAt = upB.createdAt; 

            await _context.SaveChangesAsync();

            return Ok(await _context.Budgets
                .Where(b => b.UserId == userId)
                .ToListAsync());
        }


        [HttpDelete]
        public async Task<ActionResult<List<Budget>>> DeleteBudget(int id)
        {
            var userId = _userManager.GetUserId(User);

            var budget = await _context.Budgets
                .FirstOrDefaultAsync(b => b.Id == id && b.UserId == userId);

            if (budget is null)
                return NotFound("Budget not found.");

            _context.Budgets.Remove(budget);
            await _context.SaveChangesAsync();

            return Ok(await _context.Budgets
                .Where(b => b.UserId == userId)
                .ToListAsync());
        }
    }
}

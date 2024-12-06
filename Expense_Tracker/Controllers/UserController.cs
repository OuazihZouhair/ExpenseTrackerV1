using Expense_Tracker.Data;
using Expense_Tracker.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _context.User.ToListAsync();
            return Ok(users);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user is null)
                return NotFound("User not found.");

            return Ok(user);
        }


        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User u)
        {
            _context.User.Add(u);
            await _context.SaveChangesAsync();

            return Ok(await _context.User.ToListAsync());
        }


        [HttpPut]
        public async Task<ActionResult<List<User>>> UpdateUser(User upUs)
        {
            var user = await _context.User.FindAsync(upUs.Id);
            if (user is null)
                return NotFound("User not found.");

            user.fName = upUs.fName;
            user.lName = upUs.lName;
            user.email = upUs.email;

            await _context.SaveChangesAsync();

            return Ok(await _context.User.ToListAsync());
        }


        [HttpDelete]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user is null)
                return NotFound("User not found.");

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(await _context.User.ToListAsync());
        }
    }
}

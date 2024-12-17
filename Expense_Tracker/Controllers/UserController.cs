using Expense_Tracker.Data;
using Expense_Tracker.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker.Controllers
{
    /*[Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = _userManager.Users.ToList(); // Identity provides a queryable Users property
            return Ok(users);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user is null)
                return NotFound("User not found.");

            return Ok(user);
        }


        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User newUser)
        {
            // WE should ensure that `newUser` has a username and password for proper Identity management
            var result = await _userManager.CreateAsync(newUser, "DefaultPassword123!"); // Replace with a proper password

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(newUser);
        }


        [HttpPut]
        public async Task<ActionResult<User>> UpdateUser(string id, [FromBody] User updatedUser)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user is null)
                return NotFound("User not found.");

            user.budgetId = updatedUser.budgetId;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(user);
        }


        [HttpDelete]
        public async Task<ActionResult<List<User>>> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user is null)
                return NotFound("User not found.");

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("User deleted successfully.");
        } 
    } */
}

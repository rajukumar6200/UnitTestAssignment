using Microsoft.AspNetCore.Mvc;
using UserOrderSystem.Repositories;

namespace UnitTestAssignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserservice _userService;

        public UsersController(IUserservice userService)
        {
            _userService = userService;
        }

        // GET: api/users/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
                return NotFound($"User with ID {id} not found.");

            return Ok(user);
        }
    }
}

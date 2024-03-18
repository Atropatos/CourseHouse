using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourseHouse.Data;
using CourseHouse.Models;


namespace CourseHouse.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _context.user?.ToListAsync()!;

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {

            var user = await _context.user!.FindAsync(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User newUser)
        {
            var roleExists = _context.role!.Any(r => r.RoleId == newUser.RoleId);
            if (!roleExists)
                return BadRequest("Provided role doesnt not exits!");

            await _context.user!.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserById), new { Id = newUser.UserId }, newUser);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] User updatedUser)
        {

            var user = await _context.user!.FirstOrDefaultAsync(x => x.UserId == id);
            if (user == null)
                return NotFound(updatedUser.UserId);

            user.Name = updatedUser.Name;
            user.LastName = updatedUser.LastName;
            user.Email = updatedUser.Email;
            user.RoleId = updatedUser.RoleId;

            await _context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {

            var user = await _context.user!.FirstOrDefaultAsync(x => x.UserId == id);
            if (user == null)
                return NotFound(id);

            _context.user?.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

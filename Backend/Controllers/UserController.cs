using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourseHouse.Data;
using CourseHouse.Models;
using CoursesHouse.Interfaces;


namespace CourseHouse.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserRepository _userRepo;
        public UserController(ApplicationDbContext context, IUserRepository userRepo)
        {
            _context = context;
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepo.GetAllAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {

            var user = await _userRepo.GetByIdAsync(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User newUser)
        {
            var roleExists = _context.role!.Any(r => r.RoleId == newUser.RoleId);
            if (!roleExists)
                return BadRequest("Provided role does not exits!");

            await _userRepo.CreateAsync(newUser);

            return CreatedAtAction(nameof(GetUserById), new { Id = newUser.UserId }, newUser);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] User updatedUser)
        {

            var user = await _userRepo.UpdateAsync(id,updatedUser);
            if (user == null)
                return NotFound(updatedUser.UserId);

           
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



using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourseHouse.Data;
using CourseHouse.Models;


namespace CourseHouse.Controllers
{
    [Route("api/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public RoleController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _context.role?.ToListAsync()!;

            return Ok(roles);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] Role newRole)
        {
            var roleExists = _context.role!.Any(r => r.RoleName == newRole.RoleName);
            if (roleExists)
                return BadRequest("Provided role already exists!");

            await _context.role!.AddAsync(newRole);
            await _context.SaveChangesAsync();

            return Ok(newRole.RoleName);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteRole([FromRoute] int id)
        {
            var role = await _context.role!.FirstOrDefaultAsync(x => x.RoleId == id);
            if (role == null)
                return NotFound(id);

            _context.role?.Remove(role);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourseHouse.Data;
using CourseHouse.Models;
using CoursesHouse.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Backend.Dtos.UserDtos;
using System.Security.Claims;
using Backend.Mappers;
using Backend.Dtos;
using api.Extensions;
using Microsoft.AspNetCore.Identity;

namespace CourseHouse.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly UserManager<User> _userManager;
        public UserController(IUserRepository userRepo, UserManager<User> userManager)
        {
            _userRepo = userRepo;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepo.GetAllAsync();
            var usersWithRoles = new List<UserDto>();

            foreach (var user in users)
            {
                var roles = await _userRepo.GetUserRolesAsync(user.Id);
                var userDto = user.ToUserDto();
                userDto.Roles = roles.ToList();
                usersWithRoles.Add(userDto);
            }

            return Ok(usersWithRoles);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetUserById([FromRoute] string id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null)
                return NotFound();
            var userRole = await _userRepo.GetUserRolesAsync(user.Id);
            return Ok(new { user, userRole });
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateUser([FromRoute] string id, [FromBody] UserUpdateDto updatedUserDto)
        {
            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound();
            }
            if (user.Id != id)
            {
                return Forbid();
            }

            var updatedUser = updatedUserDto.ToUserFromUserUpdatedDto();

            var result = await _userRepo.UpdateAsync(id, updatedUser);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUser([FromRoute] string id)
        {
            var user = await _userRepo.DeleteAsync(id);
            if (user == null)
                return NotFound(id);

            return NoContent();
        }
        [HttpPut("{id}/password")]
        [Authorize]
        public async Task<IActionResult> UpdatePassword(string id, [FromBody] PasswordUpdateDto passwordUpdateDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId != id)
            {
                return Forbid("Bad user!");
            }

            var result = await _userRepo.UpdatePasswordAsyncWithValidation(id, passwordUpdateDto.CurrentPassword, passwordUpdateDto.NewPassword);
            if (result)
            {
                return Ok();
            }

            return BadRequest("Password update failed");
        }
    }
}

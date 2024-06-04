using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Interfaces;
using CourseHouse.Data;
using CourseHouse.Models;
using CoursesHouse.Dtos.Courses;
using CoursesHouse.Interfaces;
using CoursesHouse.Mappers;
using Backend.Mappers;
using Backend.Dtos.Courses;
using api.Extensions;
using Backend.Models.CourseModels;

namespace Backend.Controllers
{
    [Route("api/course-category")]
    [ApiController]
    public class CourseCategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICourseCategoryRepository _courseCategoryRepo;
        private readonly UserManager<User> _userManager;

        public CourseCategoryController(ApplicationDbContext context, ICourseCategoryRepository courseCategoryRepository, UserManager<User> userManager)
        {
            _courseCategoryRepo = courseCategoryRepository;
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categories = await _courseCategoryRepo.GetAllAsync();
            var categoriesDto = categories.Select(c => c.ToCourseCategoryDto());

            return Ok(categoriesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _courseCategoryRepo.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateCourseCategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);

            var category = categoryDto.ToCourseCategoryFromCreate();
            if (category == null)
            {
                return BadRequest("Invalid category data!");
            }
            await _courseCategoryRepo.CreateAsync(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Create), new { Id = category.CategoryId }, category);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, CreateCourseCategoryDto updatedCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var category = updatedCategory.ToCourseCategoryFromCreate();
            category = await _courseCategoryRepo.UpdateAsync(id, updatedCategory);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _courseCategoryRepo.DeleteAsync(id);
            if (category == null)
            {
                return NotFound("Category does not exist");
            }

            return NoContent();
        }
    }
}

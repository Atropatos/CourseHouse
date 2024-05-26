using System.Data.Common;
using System.Linq;
using api.Extensions;
using Backend.Interfaces;
using Backend.Models.CourseModels;
using Backend.Repository;
using CourseHouse.Data;
using CourseHouse.Models;
using CoursesHouse.Dtos.Course;
using CoursesHouse.Interfaces;
using CoursesHouse.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoursesHouse.Controllers
{

    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICourseRepository _courseRepo;
        private readonly UserManager<User> _userManager;
        private readonly ICourseCategoryRepository _courseCategoryRepo;

        public CourseController(ApplicationDbContext context, ICourseRepository courseRepository, UserManager<User> userManager, ICourseCategoryRepository courseCategoryRepo)
        {
            _courseRepo = courseRepository;
            _context = context;
            _userManager = userManager;
            _courseCategoryRepo = courseCategoryRepo;
        }
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var courses = await _courseRepo.GetAllAsync();

            var coursesDto = courses.Select(s => s.ToCourseDto());

            return Ok(coursesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = await _courseRepo.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            var courseDto = course.ToCourseDto();
            return Ok(courseDto);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateCourseDto courseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);
            var course = courseDto.ToCourseFromCreate();
            if (course == null)
            {
                return BadRequest("Stock does not exist!");
            }

            course.UserId = user.Id;
            await _courseRepo.CreateAsync(course);

            var categories = await _courseCategoryRepo.GetCourseCategoriesByIds(courseDto.CategoryIds);
            var courseCategoryMappings = categories.Select(cat => new CourseCategoryMapping
            {
                CourseId = course.CourseId,
                CategoryId = cat.CategoryId
            }).ToList();

            await _context.CourseCategoryMappings.AddRangeAsync(courseCategoryMappings);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Create), new { Id = course.CourseId }, course);
        }

        [HttpPut]
        [Authorize]
        [Route("{id}")]

        public async Task<IActionResult> Update([FromRoute] int id, CreateCourseDto updatedCourse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var course = await _courseRepo.GetByIdAsync(id);

            if (course == null)
            {
                return NotFound("Course does not exist");
            }

            course = await _courseRepo.UpdateAsync(id, course);

            // Update course categories
            var categories = await _courseCategoryRepo.GetCourseCategoriesByIds(updatedCourse.CategoryIds);
            var existingMappings = await _context.CourseCategoryMappings.Where(mapping => mapping.CourseId == id).ToListAsync();
            _context.CourseCategoryMappings.RemoveRange(existingMappings);
            var newMappings = categories.Select(cat => new CourseCategoryMapping
            {
                CourseId = id,
                CategoryId = cat.CategoryId
            }).ToList();
            await _context.CourseCategoryMappings.AddRangeAsync(newMappings);
            await _context.SaveChangesAsync();

            var courseDto = course.ToCourseDto();
            return Ok(courseDto);
        }

        [HttpDelete]
        [Authorize]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = await _courseRepo.DeleteAsync(id);

            if (course == null)
            {
                return NotFound("Course does not exist");
            }
            return Ok(course);
        }
    }

}

using api.Extensions;
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

        public CourseController(ApplicationDbContext context, ICourseRepository courseRepository, UserManager<User> userManager)
        {
            _courseRepo = courseRepository;
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
            if(course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCourseDto courseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);

            var course = courseDto.ToCourseFromCreate();
            course.UserId = user.Id;

            await _courseRepo.CreateAsync(course);

            return CreatedAtAction(nameof(Create), new { Id = course.CourseId }, course);
        }

        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Course updatedCourse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = await _courseRepo.UpdateAsync(id, updatedCourse);

            if (course == null)
            {
                return null;
            }
            return Ok(course);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = await _courseRepo.DeleteAsync(id);

            if(course == null)
            {
                return NotFound("Course does not exist");
            }
            return Ok(course);
        }
    }

}

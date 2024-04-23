using CourseHouse.Data;
using CourseHouse.Models;
using CoursesHouse.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

        public CourseController(ApplicationDbContext context, ICourseRepository courseRepository)
        {
            _courseRepo = courseRepository;
            _context = context;
        }
        [HttpGet]
  
        public async Task<IActionResult> GetAll()
        {
            var courses = await _courseRepo.GetAllAsync();

            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var course = await _courseRepo.GetByIdAsync(id);
            if(course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Course course)
        {
            await _courseRepo.CreateAsync(course);

            return CreatedAtAction(nameof(Create), new { Id = course.CourseId }, course);
        }

        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Course updatedCourse)
        {
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

            var course = await _courseRepo.DeleteAsync(id);

            if(course == null)
            {
                return NotFound("Course does not exist");
            }
            return Ok(course);
        }
    }

}

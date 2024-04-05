using CourseHouse.Data;
using CourseHouse.Models;
using CoursesHouse.Interfaces;
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
            var course = await _context.course.FindAsync(id);
            if(course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Course course)
        {
            await _context.course.AddAsync(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Create), new { Id = course.CourseId }, course);
        }

        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Course updatedCourse)
        {
            var course = await _context.course!.FirstOrDefaultAsync(x => x.CourseId == id);

            course.CourseName = updatedCourse.CourseName;
            course.CoursePrice = updatedCourse.CoursePrice;

            await _context.SaveChangesAsync();
            return Ok(course);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var course = await _context.course.FirstOrDefaultAsync(x => x.CourseId == id);

             if( course == null) 
            {
                return NotFound();
            }
            _context.course.Remove(course);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}

using CoursesHouse.Repository;
using Microsoft.AspNetCore.Mvc;
using CoursesHouse.Interfaces;
using CourseHouse.Models;
using Microsoft.AspNetCore.Identity;
using CoursesHouse.Mappers;

namespace CoursesHouse.Controllers
{
    [Route("api/courseView")]
    [ApiController]
    public class CourseViewController : ControllerBase
    {
        private readonly ICourseViewRepository _courseViewRepo;
        private readonly ICourseRepository _courseRepo;
        private readonly UserManager<User> _userManager;

        public CourseViewController(ICourseViewRepository courseViewRepository, ICourseRepository courseRepository, UserManager<User> _userManager)
        {
            _courseViewRepo = courseViewRepository;
            _courseRepo = courseRepository;
            _userManager = _userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var courseView = await _courseViewRepo.getAllAsync();

            var courseViewDto = courseView.Select(s => s.ToCourseViewDto());
            return Ok(courseViewDto);
        }

        //, [FromBody] CreateCourseViewDto courseViewDto
        [HttpPost]
        [Route("{courseId}")]

        public async Task<IActionResult> Create([FromRoute] int courseId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var course = await _courseRepo.GetByIdAsync(courseId);
            if (course == null)
            {
                return NotFound("Course not found.");
            }

            var courseView = new CourseView
            {
                CourseId = courseId,
                Course = course,
                Content = new List<Content>(),
                Pictures = new List<Picture>(),
                Videos = new List<Video>(),
                TestAnswers = new List<TestAnswer>()
            };

            await _courseViewRepo.CreateAsync(courseView);

            

            return CreatedAtAction(nameof(Create), new { id = courseView.ViewId }, courseView);



        }

        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var courseView = await _courseViewRepo.GetByIdAsync(id);

            if (courseView == null)
            {
                return NotFound();
            }


            return Ok(courseView);
           // return Ok(comment.ToCommentDto());
        }

    }
}

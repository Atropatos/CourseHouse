using CourseHouse.Data;
using CourseHouse.Models;
using CoursesHouse.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CoursesHouse.Mappers;
using CoursesHouse.Dtos.Content;
using Microsoft.AspNetCore.Identity;
using api.Extensions;
using Microsoft.EntityFrameworkCore;
namespace CoursesHouse.Controllers
{
    
    [Route("api/content")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IContentRepository _contentRepo;
        private readonly UserManager<User> _userManager;
        private readonly ICourseRepository _courseRepository;

        public ContentController(ApplicationDbContext context, IContentRepository contentRepository, UserManager<User> userManager, ICourseRepository courseRepository)
        {
            _contentRepo = contentRepository;
            _context = context;
            _userManager = userManager;
            _courseRepository = courseRepository;
        }


       [HttpGet]

       public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var content = await _contentRepo.getAllAsync();
            return Ok(content);
        }

        [HttpPost]
        [Route("{courseId}")]

        public async Task<IActionResult> Create([FromRoute] int courseId,[FromBody] CreateContentDto contentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = await _courseRepository.GetByIdAsync(courseId);

            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);
            if (course == null)
            {
                return NotFound("Course not found");
            }

            var content = contentDto.ToContentFromCreate(courseId);
            content.AuthorId = user.Id;

            await _contentRepo.CreateAsync(content);

            return CreatedAtAction(nameof(Create), new { Id = content.ContentId }, content);

        }
    }
}

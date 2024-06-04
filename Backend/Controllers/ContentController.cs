using CourseHouse.Data;
using CourseHouse.Models;
using CoursesHouse.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CoursesHouse.Mappers;
using CoursesHouse.Dtos.Contents;
using Microsoft.AspNetCore.Identity;
using api.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Backend.Dtos.Contents;

namespace CoursesHouse.Controllers
{
    [Route("api/content")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IContentRepository _contentRepo;
        private readonly UserManager<User> _userManager;
        private readonly ICourseViewRepository _courseViewRepository;

        public ContentController(ApplicationDbContext context, IContentRepository contentRepository, UserManager<User> userManager, ICourseViewRepository courseViewRepository)
        {
            _contentRepo = contentRepository;
            _context = context;
            _userManager = userManager;
            _courseViewRepository = courseViewRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contents = await _contentRepo.GetAllAsync();
            if (contents == null)
            {
                return NotFound();
            }
            var contentDtos = contents.Select(c => c.ToContentDto());
            return Ok(contentDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var content = await _contentRepo.GetByIdAsync(id);
            if (content == null)
            {
                return NotFound();
            }
            var contentDto = content.ToContentDto();
            return Ok(contentDto);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateContentDto contentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var courseView = await _courseViewRepository.GetByIdAsync(contentDto.CourseViewId);
            if (courseView == null)
            {
                return BadRequest("CourseView not found");
            }
            var maxOrder = await _contentRepo.GetMaxContentOrder(contentDto.CourseViewId);
            var content = contentDto.ToContentFromCreate();
            content.Order = maxOrder + 1;
            var createdContent = await _contentRepo.CreateAsync(content);

            return CreatedAtAction(nameof(GetById), new { id = createdContent.ContentId }, createdContent.ToContentDto());
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] CreateContentDto updatedContent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingContent = await _contentRepo.GetByIdAsync(id);
            if (existingContent == null)
            {
                return NotFound();
            }
            var updatedContentEntity = await _contentRepo.UpdateAsync(id, updatedContent.ToContentFromCreate());
            return Ok(updatedContentEntity);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await _contentRepo.ChangeOrderContent(id);
            var deletedContent = await _contentRepo.DeleteAsync(id);
            if (deletedContent == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("swap-order")]
        [Authorize]
        public async Task<IActionResult> SwapOrder([FromBody] SwapOrderContentDto swapOrderDto)
        {
            var content1 = await _contentRepo.GetByIdAsync(swapOrderDto.ContentId1);
            var content2 = await _contentRepo.GetByIdAsync(swapOrderDto.ContentId2);

            if (content1 == null || content2 == null)
            {
                return NotFound("One or both Content not found.");
            }
            if (content1.CourseViewId != content2.CourseViewId)
            {
                return BadRequest("Content are not from the same course.");
            }

            var tempOrder = content1.Order;
            content1.Order = content2.Order;
            content2.Order = tempOrder;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

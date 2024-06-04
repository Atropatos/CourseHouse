using CoursesHouse.Repository;
using Microsoft.AspNetCore.Mvc;
using CoursesHouse.Interfaces;
using CourseHouse.Models;
using Microsoft.AspNetCore.Identity;
using CoursesHouse.Mappers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using CourseHouse.Data;
using CoursesHouse.Dtos.CourseViews;
using Microsoft.AspNetCore.Authorization;
using Backend.Dtos.CourseViews;

namespace CoursesHouse.Controllers
{
    [Route("api/courseView")]
    [ApiController]
    public class CourseViewController : ControllerBase
    {
        private readonly ICourseViewRepository _courseViewRepo;
        private readonly ICourseRepository _courseRepo;
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public CourseViewController(ApplicationDbContext context, ICourseViewRepository courseViewRepository, ICourseRepository courseRepository, UserManager<User> userManager)
        {
            _courseViewRepo = courseViewRepository;
            _courseRepo = courseRepository;
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var courseViews = await _courseViewRepo.GetAllAsync();
            if (courseViews == null)
            {
                return NotFound();
            }
            var courseViewDtos = courseViews.Select(c => c.ToCourseViewDto());
            return Ok(courseViewDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var courseView = await _courseViewRepo.GetByIdAsync(id);
            if (courseView == null)
            {
                return NotFound();
            }
            var courseViewDto = courseView.ToCourseViewDto();
            return Ok(courseViewDto);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateCourseViewDto courseViewDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var course = await _courseRepo.GetByIdAsync(courseViewDto.CourseId);
            if (course == null)
            {
                return NotFound("Course not found.");
            }


            var maxOrder = await _courseViewRepo.GetMaxCourseViewOrder(courseViewDto.CourseId);
            var courseView = courseViewDto.ToCourseFromCreate();
            courseView.CourseViewOrder = maxOrder + 1;
            var createdCourseView = await _courseViewRepo.CreateAsync(courseView);
            return CreatedAtAction(nameof(GetById), new { id = createdCourseView.ViewId }, createdCourseView.ToCourseViewDto());
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] CreateCourseViewDto updatedCourseView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingCourseView = await _courseViewRepo.GetByIdAsync(id);
            if (existingCourseView == null)
            {
                return NotFound();
            }

            var updatedCourseViewEntity = await _courseViewRepo.UpdateAsync(id, updatedCourseView.ToCourseFromCreate());
            return Ok(updatedCourseViewEntity);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await _courseViewRepo.ChangeOrderCourseViews(id);
            var deletedCourseView = await _courseViewRepo.DeleteAsync(id);
            if (deletedCourseView == null)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpPut("swap-order")]
        [Authorize]
        public async Task<IActionResult> SwapOrder([FromBody] SwapCourseViewOrderDto swapOrderDto)
        {
            var courseView1 = await _courseViewRepo.GetByIdAsync(swapOrderDto.CourseViewId1);
            var courseView2 = await _courseViewRepo.GetByIdAsync(swapOrderDto.CourseViewId2);

            if (courseView1 == null || courseView2 == null)
            {
                return NotFound("One or both CourseViews not found.");
            }
            if (courseView1.CourseId != courseView2.CourseId)
            {
                return BadRequest("CourseViews are not from the same course.");
            }

            var tempOrder = courseView1.CourseViewOrder;
            courseView1.CourseViewOrder = courseView2.CourseViewOrder;
            courseView2.CourseViewOrder = tempOrder;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
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
            var courseView = courseViewDto.ToCourseFromCreate();
            var createdCourseView = await _courseViewRepo.CreateAsync(courseView);
            return CreatedAtAction(nameof(GetById), new { id = createdCourseView.ViewId }, createdCourseView);
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var deletedCourseView = await _courseViewRepo.DeleteAsync(id);
            if (deletedCourseView == null)
            {
                return NotFound();
            }
            return Ok(deletedCourseView);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Extensions;
using Backend.Dtos.Courses;
using Backend.Interfaces;
using Backend.Mappers;
using CourseHouse.Data;
using CourseHouse.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/grade")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IGradeRepository _gradeRepo;
        private readonly UserManager<User> _userManager;

        public GradeController(ApplicationDbContext context, IGradeRepository gradeRepository, UserManager<User> userManager)
        {
            _gradeRepo = gradeRepository;
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var grades = await _gradeRepo.GetAllAsync();
            if (grades.Count() == 0)
            {
                return NotFound();
            }
            var gradesDto = grades.Select(c => c.ToGradeDto());
            return Ok(gradesDto);
        }

        [HttpGet("grade/{courseId}")]
        public async Task<IActionResult> GetAllFromCourse([FromRoute] int courseId)
        {
            var grades = await _gradeRepo.GetAllFromCourseAsync(courseId);
            if (grades.Count() == 0)
            {
                return NotFound();
            }
            var gradesDto = grades.Select(c => c.ToGradeDto());
            return Ok(gradesDto);
        }


        [HttpGet("{gradeId}")]
        public async Task<IActionResult> GetById(int gradeId)
        {
            var grade = await _gradeRepo.GetByIdAsync(gradeId);
            if (grade == null)
            {
                return NotFound();
            }

            return Ok(grade);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] GradeCreateDto gradeCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return Unauthorized();
            }
            var course = await _context.course!.FirstOrDefaultAsync(x => x.CourseId == gradeCreate.CourseId);
            if (course == null)
            {
                return NotFound("Course not found.");
            }
            var grade = gradeCreate.ToGradeFromCreate();

            grade.AuthorId = user.Id;
            grade.CourseId = course.CourseId;
            grade.Author = user;
            grade.Course = course;

            var created = await _gradeRepo.CreateAsync(grade);

            return CreatedAtAction(nameof(GetById), new { gradeId = created.Id }, created.ToGradeDto());
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] decimal updatedGrade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return Unauthorized();
            }

            var existingGrade = await _gradeRepo.GetByIdAsync(id);
            if (existingGrade == null)
            {
                return NotFound();
            }

            var updated = await _gradeRepo.UpdateAsync(id, updatedGrade);
            return Ok(updated.ToGradeDto());
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return Unauthorized();
            }

            var delete = await _gradeRepo.DeleteAsync(id);
            if (delete == null)
            {
                return NotFound();
            }
            return Ok(delete);
        }
    }
}
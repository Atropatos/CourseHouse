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
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICommentRepository _commentRepo;
        private readonly UserManager<User> _userManager;

        public CommentController(ApplicationDbContext context, ICommentRepository commentRepository, UserManager<User> userManager)
        {
            _commentRepo = commentRepository;
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepo.GetAllAsync();
            if (comments == null)
            {
                return NotFound();
            }
            var commentDto = comments.Select(c => c.ToCommentDto());
            return Ok(commentDto);
        }

        [HttpGet("course/{courseId}")]
        public async Task<IActionResult> GetAllFromCourse([FromRoute] int courseId)
        {
            var comments = await _commentRepo.GetAllFromCourseAsync(courseId);
            if (comments.Count() == 0)
            {
                return NotFound();
            }
            var commentDto = comments.Select(c => c.ToCommentDto());
            return Ok(commentDto);
        }


        [HttpGet("{commentId}")]
        public async Task<IActionResult> GetById(int commentId)
        {
            var comment = await _commentRepo.GetByIdAsync(commentId);
            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CommentCreateDto commentCreate)
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
            var course = await _context.course!.FirstOrDefaultAsync(x => x.CourseId == commentCreate.CourseId);
            if (course == null)
            {
                return NotFound("Course not found.");
            }
            var comment = commentCreate.ToCommentFromCreate();

            comment.AuthorId = user.Id;
            comment.CourseId = course.CourseId;
            comment.Author = user;
            comment.Course = course;

            var created = await _commentRepo.CreateAsync(comment);

            return CreatedAtAction(nameof(GetById), new { commentId = created.Id }, created.ToCommentDto());
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] string updatedComment)
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

            var existingComment = await _commentRepo.GetByIdAsync(id);
            if (existingComment == null)
            {
                return NotFound();
            }

            var updated = await _commentRepo.UpdateAsync(id, updatedComment);
            return Ok(updated.ToCommentDto());
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

            var delete = await _commentRepo.DeleteAsync(id);
            if (delete == null)
            {
                return NotFound();
            }
            return Ok(delete);
        }
    }
}
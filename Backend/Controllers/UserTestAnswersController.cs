using System.Data.Common;
using System.Linq;
using api.Extensions;
using Backend.Dtos.UserTestAnswers;
using Backend.Interfaces;
using Backend.Mappers;
using Backend.Models.CourseModels;
using Backend.Repository;
using CourseHouse.Data;
using CourseHouse.Models;
using CoursesHouse.Dtos.Courses;
using CoursesHouse.Interfaces;
using CoursesHouse.Mappers;
using Google.Protobuf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/userTestAnswers")]
    [ApiController]
    public class UserTestAnswersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IUserTestAnswers _answersRepo;

        public UserTestAnswersController(ApplicationDbContext context, UserManager<User> userManager, IUserTestAnswers answersRepo)
        {
            _context = context;
            _userManager = userManager;
            _answersRepo = answersRepo;
        }
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userTestAnswers = await _answersRepo.GetAllAsync();
            var userTestAnswersDto = userTestAnswers.Select(s => s.ToUserTestAnswerDto());
            return Ok(userTestAnswersDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userTestAnswer = await _answersRepo.GetByIdAsync(id);
            if (userTestAnswer == null)
            {
                return NotFound();
            }
            var userTestAnswerDto = userTestAnswer.ToUserTestAnswerDto();
            return Ok(userTestAnswerDto);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] UserTestAnswerCreateDto userTestAnswerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingAnswers = await _answersRepo.GetAllAsync();

            var existingAnswer = existingAnswers.FirstOrDefault(a =>
                a.ContentTest == userTestAnswerDto.ContentTest &&
                a.AnswerId == userTestAnswerDto.AnswerId);

            if (existingAnswer != null)
            {
                return BadRequest("UserTestAnswer already exists!");
            }


            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);
            var userTestAnswer = userTestAnswerDto.ToUserTestAnswerFromCreate();
            if (userTestAnswer == null)
            {
                return BadRequest("UserTestAnswer does not exist!");
            }

            //ConentId
            var questionContent = await _context.content!.FirstOrDefaultAsync(c => c.ContentId == userTestAnswerDto.ContentTest);
            if (questionContent == null)
            {
                return BadRequest("Content Id does not exist!");
            }
            //Conent Answer Id
            var answer = await _context.content!.FirstOrDefaultAsync(c => c.ContentId == userTestAnswerDto.AnswerId);
            if (answer == null)
            {
                return BadRequest("Answer Id does not exist!");
            }
            //Course Id
            var courseId = await _context.content!
                            .Include(a => a.CourseView)
                            .Where(b => b.ContentId == answer.ContentId)
                            .Select(c => c.CourseView.CourseId)
                            .FirstOrDefaultAsync();

            userTestAnswer.CourseId = courseId;
            userTestAnswer.IsCorrect = answer.Correct;
            userTestAnswer.UserId = user.Id;

            await _answersRepo.CreateAsync(userTestAnswer);
            return CreatedAtAction(nameof(Create), userTestAnswer.ToUserTestAnswerDto());
        }

        [HttpPut]
        [Authorize]
        [Route("{id}")]

        public async Task<IActionResult> Update([FromRoute] int id, UserTestAnswerCreateDto updatedAnswers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);
            var userTestAnswer = updatedAnswers.ToUserTestAnswerFromCreate();
            if (userTestAnswer == null)
            {
                return BadRequest("UserTestAnswer does not exist!");
            }

            //ConentId
            var questionContent = await _context.content!.FirstOrDefaultAsync(c => c.ContentId == updatedAnswers.ContentTest);
            if (questionContent == null)
            {
                return BadRequest("Content does not exist!");
            }
            //Conent Answer Id
            var answer = await _context.content!.FirstOrDefaultAsync(c => c.ContentId == updatedAnswers.AnswerId);
            if (answer == null)
            {
                return BadRequest("Answer does not exist!");
            }
            //Course Id
            var courseId = await _context.content!
                            .Include(a => a.CourseView)
                            .Where(b => b.ContentId == answer.ContentId)
                            .Select(c => c.CourseView.CourseId)
                            .FirstOrDefaultAsync();

            userTestAnswer.CourseId = courseId;
            userTestAnswer.IsCorrect = answer.Correct;
            userTestAnswer.UserId = user.Id;

            var updated = await _answersRepo.UpdateAsync(id, userTestAnswer);

            var courseDto = updated.ToUserTestAnswerDto();
            return Ok(courseDto);
        }

        [HttpDelete]
        [Authorize]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userTestAnswer = await _answersRepo.DeleteAsync(id);

            if (userTestAnswer == null)
            {
                return NotFound("UserTestAnswer does not exist");
            }
            return Ok(userTestAnswer);
        }
    }
}
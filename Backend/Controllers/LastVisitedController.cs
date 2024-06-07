using Microsoft.AspNetCore.Mvc;
using Backend.Dtos.LastVitited;
using Backend.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Backend.Mappers;
using CourseHouse.Models;
using Microsoft.AspNetCore.Identity;
using api.Extensions;

namespace Backend.Controllers
{
    [Route("api/lastVisited")]
    [ApiController]
    [Authorize]
    public class LastVisitedController : ControllerBase
    {
        private readonly ILastVisitedRepository _lastVisitedRepository;
        private readonly UserManager<User> _userManager;

        public LastVisitedController(ILastVisitedRepository lastVisitedRepository, UserManager<User> userManager)
        {
            _lastVisitedRepository = lastVisitedRepository;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLastVisitedDto lastVisitedDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userName = User.GetUsername();
            var user = await _userManager.FindByNameAsync(userName);

            var lastVisited = lastVisitedDto.ToLastVisitedFromCreateDto();
            lastVisited.UserId = user.Id;
            var createdLastVisited = await _lastVisitedRepository.CreateAsync(lastVisited);

            return CreatedAtAction(nameof(GetById), new { id = createdLastVisited.LastVisitedId }, createdLastVisited);
        }

        [HttpGet("/api/lastFive")]
        public async Task<IActionResult> GetLastFiveUserVisits()
        {
            var userName = User.GetUsername();
            var user = await _userManager.FindByNameAsync(userName);

            var lastVisited = await _lastVisitedRepository.GetLastFiveUserVisits(user.Id);
            if (lastVisited == null)
            {
                return NotFound();
            }
            var dto = lastVisited.Select(x => x.ToLastVisitedDto()).ToList();
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var lastVisited = await _lastVisitedRepository.GetByIdAsync(id);
            if (lastVisited == null)
            {
                return NotFound();
            }
            return Ok(lastVisited.ToLastVisitedDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateLastVisitedDto updatedLastVisited)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingLastVisited = await _lastVisitedRepository.GetByIdAsync(id);
            if (existingLastVisited == null)
            {
                return NotFound();
            }

            var updatedLastVisitedEntity = await _lastVisitedRepository.UpdateAsync(id, updatedLastVisited);
            if (updatedLastVisitedEntity == null)
            {
                return BadRequest("Failed to update last visited.");
            }

            return Ok(updatedLastVisitedEntity.ToLastVisitedDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedLastVisited = await _lastVisitedRepository.DeleteAsync(id);
            if (deletedLastVisited == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lastVisitedItems = await _lastVisitedRepository.GetAllAsync();
            var dto = lastVisitedItems.Select(x => x.ToLastVisitedDto()).ToList();

            return Ok(dto);
        }
    }
}

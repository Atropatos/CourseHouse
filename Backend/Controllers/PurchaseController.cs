using Microsoft.AspNetCore.Mvc;
using Backend.Dtos.Purchases;
using Backend.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Backend.Mappers;
using CourseHouse.Models;
using Microsoft.AspNetCore.Identity;
using api.Extensions;
using CoursesHouse.Interfaces;

namespace Backend.Controllers
{
    [Route("api/purchase")]
    [ApiController]
    [Authorize]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly UserManager<User> _userManager;
        private readonly ICourseRepository _courseRepository;

        public PurchaseController(IPurchaseRepository purchaseRepository, UserManager<User> userManager, ICourseRepository courseRepository)
        {
            _purchaseRepository = purchaseRepository;
            _userManager = userManager;
            _courseRepository = courseRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePurchaseDto purchaseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userName = User.GetUsername();
            var user = await _userManager.FindByNameAsync(userName);

            var course = await _courseRepository.GetByIdAsync(purchaseDto.CourseId);
            if (course == null)
            {
                return BadRequest("Course not found.");
            }

            var purchase = purchaseDto.ToPurchaseFromCreateDto();
            purchase.UserId = user.Id;
            purchase.Spend = course.CoursePrice;
            var createdPurchase = await _purchaseRepository.CreateAsync(purchase);

            return CreatedAtAction(nameof(GetById), new { id = createdPurchase.PurchaseId }, createdPurchase);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var purchase = await _purchaseRepository.GetByIdAsync(id);
            if (purchase == null)
            {
                return NotFound();
            }
            return Ok(purchase.ToPurchaseDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreatePurchaseDto updatedPurchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingPurchase = await _purchaseRepository.GetByIdAsync(id);
            if (existingPurchase == null)
            {
                return NotFound();
            }

            var course = await _courseRepository.GetByIdAsync(updatedPurchase.CourseId);
            if (course == null)
            {
                return BadRequest("Course not found.");
            }

            var updatedPurchaseEntity = await _purchaseRepository.UpdateAsync(id, updatedPurchase);
            if (updatedPurchaseEntity == null)
            {
                return BadRequest("Failed to update purchase.");
            }

            return Ok(updatedPurchaseEntity.ToPurchaseDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedPurchase = await _purchaseRepository.DeleteAsync(id);
            if (deletedPurchase == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var purchases = await _purchaseRepository.GetAllAsync();
            var dto = purchases.Select(x => x.ToPurchaseDto()).ToList();
            return Ok(dto);
        }

        [HttpGet("/api/user/purchases")]
        public async Task<IActionResult> GetUserPurchases()
        {
            var userName = User.GetUsername();
            var user = await _userManager.FindByNameAsync(userName);

            var purchases = await _purchaseRepository.GetByUserIdAsync(user.Id);
            var dto = purchases.Select(x => x.ToPurchaseDto()).ToList();
            return Ok(dto);
        }
    }
}

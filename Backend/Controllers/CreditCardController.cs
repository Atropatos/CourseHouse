using Microsoft.AspNetCore.Mvc;
using Backend.Dtos.CreditCards;
using Backend.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Backend.Mappers;
using CourseHouse.Models;
using Microsoft.AspNetCore.Identity;
using api.Extensions;

namespace Backend.Controllers
{
    [Route("api/creditcard")]
    [ApiController]
    [Authorize]
    public class CreditCardController : ControllerBase
    {
        private readonly ICreditCardRepository _creditCardRepository;
        private readonly UserManager<User> _userManager;

        public CreditCardController(ICreditCardRepository creditCardRepository, UserManager<User> userManager)
        {
            _creditCardRepository = creditCardRepository;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCreditCardDto creditCardDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userName = User.GetUsername();
            var user = await _userManager.FindByNameAsync(userName);

            var creditCard = creditCardDto.ToCreditCardFromCreateDto();
            creditCard.UserId = user.Id;
            var createdCreditCard = await _creditCardRepository.CreateAsync(creditCard);

            return CreatedAtAction(nameof(GetById), new { id = createdCreditCard.CreditCardId }, createdCreditCard);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var creditCard = await _creditCardRepository.GetByIdAsync(id);
            if (creditCard == null)
            {
                return NotFound();
            }
            return Ok(creditCard.ToCreditCardDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateCreditCardDto updatedCreditCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingCreditCard = await _creditCardRepository.GetByIdAsync(id);
            if (existingCreditCard == null)
            {
                return NotFound();
            }

            var updatedCreditCardEntity = await _creditCardRepository.UpdateAsync(id, updatedCreditCard);
            if (updatedCreditCardEntity == null)
            {
                return BadRequest("Failed to update credit card.");
            }

            return Ok(updatedCreditCardEntity.ToCreditCardDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedCreditCard = await _creditCardRepository.DeleteAsync(id);
            if (deletedCreditCard == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var creditCards = await _creditCardRepository.GetAllAsync();
            var dto = creditCards.Select(x => x.ToCreditCardDto()).ToList();
            return Ok(dto);
        }

        [HttpGet("/api/user/creditcards")]
        public async Task<IActionResult> GetUsersCreditCards()
        {
            var userName = User.GetUsername();
            var user = await _userManager.FindByNameAsync(userName);

            var creditCards = await _creditCardRepository.GetCreditCardsByUserId(user.Id);
            var dto = creditCards.Select(x => x.ToCreditCardDto()).ToList();
            return Ok(dto);
        }
    }
}

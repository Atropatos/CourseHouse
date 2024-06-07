using Backend.Dtos.CreditCards;
using CourseHouse.Models;

namespace Backend.Mappers
{
    public static class CreditCardMapper
    {
        public static CreditCardDto ToCreditCardDto(this CreditCard creditCard)
        {
            return new CreditCardDto
            {
                CreditCardId = creditCard.CreditCardId,
                CreditCardNumber = creditCard.CreditCardNumber,
                ExpirationDate = creditCard.ExpirationDate,
                Cvv = creditCard.Cvv,
                HolderName = creditCard.HolderName,
                UserId = creditCard.UserId
            };
        }

        public static CreditCard ToCreditCardFromCreateDto(this CreateCreditCardDto createCreditCardDto)
        {
            return new CreditCard
            {
                CreditCardNumber = createCreditCardDto.CreditCardNumber,
                ExpirationDate = createCreditCardDto.ExpirationDate,
                Cvv = createCreditCardDto.Cvv,
                HolderName = createCreditCardDto.HolderName,
            };
        }
    }
}

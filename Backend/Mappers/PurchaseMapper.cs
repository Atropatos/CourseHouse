using Backend.Dtos.Purchases;
using CourseHouse.Models;

namespace Backend.Mappers
{
    public static class PurchaseMapper
    {
        public static PurchaseDto ToPurchaseDto(this Purchase purchase)
        {
            return new PurchaseDto
            {
                PurchaseId = purchase.PurchaseId,
                CourseId = purchase.CourseId,
                UserId = purchase.UserId,
                CreditCardId = purchase.CreditCardId,
                PurchasedOn = purchase.PurchasedOn,
                Spend = purchase.Spend
            };
        }

        public static Purchase ToPurchaseFromCreateDto(this CreatePurchaseDto createPurchaseDto)
        {
            return new Purchase
            {
                CourseId = createPurchaseDto.CourseId,
                CreditCardId = createPurchaseDto.CreditCardId,
                PurchasedOn = createPurchaseDto.PurchasedOn,
            };
        }
    }
}

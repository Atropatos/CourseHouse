using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos.CreditCards;
using CourseHouse.Models;

namespace Backend.Interfaces
{
    public interface ICreditCardRepository
    {
        Task<List<CreditCard>> GetAllAsync();
        Task<CreditCard> GetByIdAsync(int id);
        Task<CreditCard> DeleteAsync(int id);
        Task<CreditCard> UpdateAsync(int id, CreateCreditCardDto updatedCard);
        Task<CreditCard> CreateAsync(CreditCard card);
        Task<List<CreditCard>> GetCreditCardsByUserId(string userId);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos.CreditCards;
using Backend.Interfaces;
using CourseHouse.Data;
using CourseHouse.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class CreditCardRepository : ICreditCardRepository
    {
        private readonly ApplicationDbContext _context;

        public CreditCardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CreditCard> CreateAsync(CreditCard card)
        {
            _context.creditCard!.Add(card);
            await _context.SaveChangesAsync();
            return card;
        }

        public async Task<CreditCard> DeleteAsync(int id)
        {
            var card = await _context.creditCard!.FindAsync(id);
            if (card == null)
            {
                return null;
            }

            _context.creditCard!.Remove(card);
            await _context.SaveChangesAsync();

            return card;
        }

        public async Task<List<CreditCard>> GetAllAsync()
        {
            return await _context.creditCard!.ToListAsync();
        }

        public async Task<CreditCard> GetByIdAsync(int id)
        {
            return await _context.creditCard!.FindAsync(id);
        }

        public async Task<CreditCard> UpdateAsync(int id, CreateCreditCardDto updatedCard)
        {
            var card = await _context.creditCard!.FindAsync(id);
            if (card == null)
            {
                return null;
            }

            card.CreditCardNumber = updatedCard.CreditCardNumber;
            card.ExpirationDate = updatedCard.ExpirationDate;
            card.Cvv = updatedCard.Cvv;
            card.HolderName = updatedCard.HolderName;

            await _context.SaveChangesAsync();
            return card;
        }

        public async Task<List<CreditCard>> GetCreditCardsByUserId(string userId)
        {
            var creditCards = await _context.creditCard!.Where(x => x.UserId == userId).ToListAsync();
            return creditCards;
        }
    }
}

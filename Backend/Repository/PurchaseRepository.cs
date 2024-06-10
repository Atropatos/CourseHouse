using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos.Purchases;
using Backend.Interfaces;
using CourseHouse.Data;
using CourseHouse.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly ApplicationDbContext _context;

        public PurchaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Purchase> CreateAsync(Purchase purchase)
        {
            _context.purchase!.Add(purchase);
            _context.course!.Find(purchase.CourseId)!.EnrolledUsers.Add(_context.user!.Find(purchase.UserId)!);
            await _context.SaveChangesAsync();
            return purchase;
        }

        public async Task<Purchase> DeleteAsync(int id)
        {
            var purchase = await _context.purchase!.FindAsync(id);
            if (purchase == null)
            {
                return null;
            }

            _context.purchase!.Remove(purchase);
            await _context.SaveChangesAsync();

            return purchase;
        }

        public async Task<List<Purchase>> GetAllAsync()
        {
            return await _context.purchase!.ToListAsync();
        }

        public async Task<Purchase> GetByIdAsync(int id)
        {
            return await _context.purchase!.FindAsync(id);
        }

        public async Task<Purchase> UpdateAsync(int id, CreatePurchaseDto updatedPurchase)
        {
            var purchase = await _context.purchase!.FindAsync(id);
            if (purchase == null)
            {
                return null;
            }

            purchase.CourseId = updatedPurchase.CourseId;
            purchase.CreditCardId = updatedPurchase.CreditCardId;
            purchase.Spend = _context.course!.Find(updatedPurchase.CourseId)!.CoursePrice;

            await _context.SaveChangesAsync();
            return purchase;
        }

        public async Task<List<Purchase>> GetByUserIdAsync(string userId)
        {
            return await _context.purchase!.Where(p => p.UserId == userId).ToListAsync();
        }
    }
}

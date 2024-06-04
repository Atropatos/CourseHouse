using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos.Purchases;
using CourseHouse.Models;

namespace Backend.Interfaces
{
    public interface IPurchaseRepository
    {
        Task<List<Purchase>> GetAllAsync();
        Task<Purchase> GetByIdAsync(int id);
        Task<Purchase> DeleteAsync(int id);
        Task<Purchase> UpdateAsync(int id, CreatePurchaseDto updatedPurchase);
        Task<Purchase> CreateAsync(Purchase purchase);
        Task<List<Purchase>> GetByUserIdAsync(string userId);
    }
}
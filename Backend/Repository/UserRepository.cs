using CourseHouse.Data;
using CourseHouse.Models;
using CoursesHouse.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoursesHouse.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public UserRepository(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users!
                .Include(a => a.UserPurchases)
                .Include(a => a.UserCreditCards)
                .Include(a => a.CreatedCourses)
                .ToListAsync();
        }

        public async Task<User?> GetByIdAsync(string id)
        {
            return await _context.Users!
                .Include(a => a.UserPurchases)
                .Include(a => a.UserCreditCards)
                .Include(a => a.CreatedCourses)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> CreateAsync(User user)
        {
            var result = await _userManager.CreateAsync(user, user.PasswordHash);
            if (result.Succeeded)
            {
                await _context.SaveChangesAsync();
            }
            return user;
        }

        public async Task<User?> UpdateAsync(string id, User updatedUser)
        {
            var existingUser = await _context.Users!.FirstOrDefaultAsync(x => x.Id == id);

            if (existingUser == null)
            {
                return null;
            }

            existingUser.UserName = updatedUser.UserName;
            existingUser.Email = updatedUser.Email;
            existingUser.UserPurchases = updatedUser.UserPurchases;
            existingUser.UserCreditCards = updatedUser.UserCreditCards;
            existingUser.CreatedCourses = updatedUser.CreatedCourses;

            var result = await _userManager.UpdateAsync(existingUser);
            if (result.Succeeded)
            {
                await _context.SaveChangesAsync();
            }

            return existingUser;
        }

        public async Task<User?> DeleteAsync(string id)
        {
            var user = await _context.Users!.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return null;
            }
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                await _context.SaveChangesAsync();
            }
            return user;
        }
        public async Task<bool> UpdatePasswordAsyncWithValidation(string id, string currentPassword, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return false;
            }
            var passwordValid = await _userManager.CheckPasswordAsync(user, currentPassword);
            if (!passwordValid)
            {
                return false;
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
            if (changePasswordResult.Succeeded)
            {
                return true;
            }
            return false;
        }

        public async Task<List<string>> GetUserRolesAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return null;
            }

            return (List<string>)await _userManager.GetRolesAsync(user);
        }
    }
}

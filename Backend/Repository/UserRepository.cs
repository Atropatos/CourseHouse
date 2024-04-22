/*using CourseHouse.Data;
using CourseHouse.Models;
using CoursesHouse.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoursesHouse.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> RoleExistsAsync(int roleId)
        {
            return await _context.role.AnyAsync(r => r.RoleId == roleId);
        }
        public async Task<User> CreateAsync(User newUser)
        {
           
            await _context.user!.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }

        public async Task<User?> DeleteAsync(int id)
        {
            var user = await _context.user.FirstOrDefaultAsync(x => x.UserId == id);
            if (user == null)
            {
                return null;
            }
            _context.user.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllAsync() {
           // throw new NotImplementedException();
            return await _context.user.ToListAsync()!;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.user.FindAsync(id);
        }

        public async Task<User?> UpdateAsync(int id, User user)
        {
            var existingUser = await _context.user.FirstOrDefaultAsync(x => x.UserId == id);
            if(existingUser == null)
            {
                return null;
            }
            existingUser.Name = user.Name;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.RoleId = user.RoleId;

            await _context.SaveChangesAsync();

            return existingUser;
        }
    }
}
*/
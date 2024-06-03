using CourseHouse.Models;

namespace CoursesHouse.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(string id);

        Task<User> CreateAsync(User user);

        Task<User?> UpdateAsync(string id, User user);

        Task<User?> DeleteAsync(string id);
        Task<bool> UpdatePasswordAsyncWithValidation(string id, string currentPassword, string newPassword);
        Task<List<string>> GetUserRolesAsync(string userId);
    }
}

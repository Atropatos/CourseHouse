using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.UserModels;

namespace Backend.Interfaces
{
    public interface IUserTestAnswers
    {
        Task<List<UserTestAnswer>> GetAllAsync();
        Task<UserTestAnswer> GetByIdAsync(int id);
        Task<UserTestAnswer> DeleteAsync(int id);
        Task<UserTestAnswer> UpdateAsync(int id, UserTestAnswer updatedUserTestAnswer);
        Task<UserTestAnswer> CreateAsync(UserTestAnswer userTestAnswer);
    }
}
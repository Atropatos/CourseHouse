using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Interfaces;
using Backend.Models.UserModels;
using CourseHouse.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class UserTestAnswersRepository : IUserTestAnswers
    {
        private readonly ApplicationDbContext _context;

        public UserTestAnswersRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<UserTestAnswer>> GetAllAsync()
        {
            var userTestAnswers = await _context.userTestAnswers!.ToListAsync();
            return userTestAnswers;
        }

        public async Task<UserTestAnswer> GetByIdAsync(int id)
        {
            var userTestAnswer = await _context.userTestAnswers!.FindAsync(id);
            return userTestAnswer;
        }
        public async Task<UserTestAnswer> CreateAsync(UserTestAnswer userTestAnswer)
        {
            await _context.userTestAnswers!.AddAsync(userTestAnswer);
            await _context.SaveChangesAsync();
            return userTestAnswer;
        }

        public async Task<UserTestAnswer> UpdateAsync(int id, UserTestAnswer updatedUserTestAnswer)
        {
            var existingAnswers = await _context.userTestAnswers!.FindAsync(id);

            if (existingAnswers == null)
            {
                return null;
            }
            existingAnswers.CourseId = updatedUserTestAnswer.CourseId;
            existingAnswers.ContentTest = updatedUserTestAnswer.ContentTest;
            existingAnswers.UserId = updatedUserTestAnswer.UserId;
            existingAnswers.AnswerId = updatedUserTestAnswer.AnswerId;
            existingAnswers.IsCorrect = updatedUserTestAnswer.IsCorrect;


            await _context.SaveChangesAsync();
            return existingAnswers;
        }

        public async Task<UserTestAnswer> DeleteAsync(int id)
        {
            var answer = await _context.userTestAnswers!.FindAsync(id);
            if (answer == null)
            {
                return null;
            }

            _context.userTestAnswers!.Remove(answer);
            await _context.SaveChangesAsync();

            return answer;
        }
    }
}
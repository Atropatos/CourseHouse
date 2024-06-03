using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseHouse.Models;

namespace Backend.Interfaces
{
    public interface IGradeRepository
    {
        Task<List<CourseGrade>> GetAllAsync();
        Task<CourseGrade> GetByIdAsync(int id);
        Task<CourseGrade> DeleteAsync(int id);
        Task<CourseGrade> UpdateAsync(int id, CourseGrade updatedGrade);
        Task<CourseGrade> CreateAsync(CourseGrade grade);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos.Courses;
using Backend.Models.CourseModels;

namespace Backend.Interfaces
{
    public interface ICourseCategoryRepository
    {
        Task<List<CourseCategory>> GetAllAsync();
        Task<CourseCategory> GetByIdAsync(int id);
        Task<CourseCategory> DeleteAsync(int id);
        Task<CourseCategory> UpdateAsync(int id, CreateCourseCategoryDto updatedCourseCategory);
        Task<CourseCategory> CreateAsync(CourseCategory courseCategory);
        Task<List<CourseCategory>> GetCourseCategoriesByIds(List<int> ids);
    }
}
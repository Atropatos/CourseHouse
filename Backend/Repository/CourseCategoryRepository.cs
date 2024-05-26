using CourseHouse.Data;
using Backend.Models.CourseModels;
using Backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Dtos.Course;

namespace Backend.Repository
{
    public class CourseCategoryRepository : ICourseCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CourseCategory> CreateAsync(CourseCategory courseCategory)
        {
            await _context.courseCategory.AddAsync(courseCategory);
            await _context.SaveChangesAsync();
            return courseCategory;
        }

        public async Task<List<CourseCategory>> GetAllAsync()
        {
            return await _context.courseCategory.ToListAsync();
        }

        public async Task<CourseCategory> GetByIdAsync(int id)
        {
            return await _context.courseCategory.FirstOrDefaultAsync(cc => cc.CategoryId == id);
        }

        public async Task<CourseCategory> UpdateAsync(int id, CreateCourseCategoryDto updatedCourseCategory)
        {
            var existingCategory = await _context.courseCategory.FirstOrDefaultAsync(cc => cc.CategoryId == id);

            if (existingCategory == null)
            {
                return null;
            }

            existingCategory.CategoryName = updatedCourseCategory.CourseCategoryName;

            await _context.SaveChangesAsync();
            return existingCategory;
        }

        public async Task<CourseCategory> DeleteAsync(int id)
        {
            var category = await _context.courseCategory.FirstOrDefaultAsync(cc => cc.CategoryId == id);
            if (category == null)
            {
                return null;
            }

            _context.courseCategory.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<List<CourseCategory>> GetCourseCategoriesByIds(List<int> ids)
        {
            var categoryList = await _context.courseCategory
                .Where(cc => ids.Contains(cc.CategoryId))
                .ToListAsync();

            return categoryList;
        }
    }
}

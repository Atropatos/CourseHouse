using CourseHouse.Data;
using CourseHouse.Models;
using CoursesHouse.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoursesHouse.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task<List<Course>> GetAllAsync()
        {
            return await _context.course!
            .Include(a => a.User)
            .Include(a => a.CourseViews)
            .ThenInclude(a => a.Content)
            .Include(a => a.Comments)
            .Include(a => a.EnrolledUsers)
            .Include(a => a.Grades)
            .Include(a => a.CourseCategoryMappings)
            .ThenInclude(a => a.CourseCategory)
            .ToListAsync();
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            var course = await _context.course!
            .Include(a => a.User)
            .Include(a => a.CourseViews)
            .ThenInclude(a => a.Content)
            .Include(a => a.Comments)
            .Include(a => a.EnrolledUsers)
            .Include(a => a.Grades)
            .Include(a => a.CourseCategoryMappings)
            .ThenInclude(a => a.CourseCategory)
            .FirstOrDefaultAsync(x => x.CourseId == id);
            return course;
        }
        public async Task<Course> CreateAsync(Course course)
        {
            await _context.course.AddAsync(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<Course> DeleteAsync(int id)
        {
            var course = await _context.course.FirstOrDefaultAsync(x => x.CourseId == id);
            if (course == null)
            {
                return null;
            }
            _context.course.Remove(course);
            await _context.SaveChangesAsync();

            return course;
        }

        public async Task<Course> UpdateAsync(int id, Course updatedCourse)
        {
            var existingCourse = await _context.course!.FirstOrDefaultAsync(x => x.CourseId == id);

            if (existingCourse == null)
            {
                return null;
            }

            existingCourse.CourseName = updatedCourse.CourseName;
            existingCourse.CoursePrice = updatedCourse.CoursePrice;
            existingCourse.CourseDescription = updatedCourse.CourseDescription;

            await _context.SaveChangesAsync();
            return existingCourse;
        }
    }
}

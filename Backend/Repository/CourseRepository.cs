using CourseHouse.Data;
using CourseHouse.Models;
using CoursesHouse.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoursesHouse.Repository
{
    public class CourseRepository :ICourseRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
            
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

        public async Task<List<Course>> GetAllAsync()
        {

            return await _context.course?.Include(a => a.User).ToListAsync();
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            return await _context.course.Include(a => a.User).FirstOrDefaultAsync(x => x.CourseId == id);
        }

        public async Task<Course> UpdateAsync(int id, Course updatedCourse)
        {
             var existingCourse = await _context.course!.FirstOrDefaultAsync(x => x.CourseId == id);

            if (existingCourse==null)
            {
                return null;
            }

            existingCourse.CourseName = updatedCourse.CourseName;
            existingCourse.CoursePrice = updatedCourse.CoursePrice;

            await _context.SaveChangesAsync();
            return existingCourse;
            
        }
    }
}

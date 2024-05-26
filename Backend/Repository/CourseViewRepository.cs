using CourseHouse.Data;
using CourseHouse.Models;
using CoursesHouse.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoursesHouse.Repository
{
    public class CourseViewRepository:ICourseViewRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseViewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CourseView> CreateAsync(CourseView courseView)
        {
            await _context.courseView.AddAsync(courseView);
            await _context.SaveChangesAsync();
            return courseView;
        }

        public async Task<List<CourseView>> getAllAsync()
        {
            return await _context.courseView.Include(c=> c.Course).ToListAsync();
        }
        public async Task<CourseView> GetByIdAsync(int id)
        {
            return await _context.courseView.Include(c=> c.Course).FirstOrDefaultAsync(x => x.ViewId == id);
        }
        
    }
}

using CourseHouse.Data;
using CourseHouse.Models;
using CoursesHouse.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesHouse.Repository
{
    public class CourseViewRepository : ICourseViewRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseViewRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<CourseView>> GetAllAsync()
        {
            var coursesViews = await _context.courseView!
                                            .Include(a => a.Course)
                                            .Include(a => a.Content)
                                            .Include(a => a.Pictures)
                                            .Include(a => a.Videos)
                                            .Include(a => a.TestAnswers)
                                            .ToListAsync();
            return coursesViews;
        }

        public async Task<CourseView> GetByIdAsync(int id)
        {
            var courseView = await _context.courseView!.Include(a => a.Course)
                                            .Include(a => a.Content)
                                            .Include(a => a.Pictures)
                                            .Include(a => a.Videos)
                                            .Include(a => a.TestAnswers)
                                            .FirstOrDefaultAsync(a => a.ViewId == id);
            return courseView;
        }
        public async Task<CourseView> CreateAsync(CourseView courseView)
        {
            _context.courseView?.Add(courseView);
            await _context.SaveChangesAsync();
            return courseView;
        }
        public async Task<CourseView> UpdateAsync(int id, CourseView updatedCourseView)
        {
            var existingCourseView = await _context.courseView!.FindAsync(id);

            if (existingCourseView == null)
            {
                return null;
            }

            existingCourseView.CourseId = updatedCourseView.CourseId;

            await _context.SaveChangesAsync();
            return existingCourseView;
        }
        public async Task<CourseView> DeleteAsync(int id)
        {
            var courseView = await _context.courseView!.FindAsync(id);
            if (courseView == null)
            {
                return null;
            }

            _context.courseView.Remove(courseView);
            await _context.SaveChangesAsync();

            return courseView;
        }
    }
}

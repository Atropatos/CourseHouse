using CourseHouse.Data;
using CourseHouse.Models;
using CoursesHouse.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
                                            .ThenInclude(a => a.User)
                                            .Include(a => a.Content)
                                            .ToListAsync();
            return coursesViews;
        }

        public async Task<CourseView> GetByIdAsync(int id)
        {
            var courseView = await _context.courseView!.Include(a => a.Course)
                                            .ThenInclude(a => a.User)
                                            .Include(a => a.Content)
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
            existingCourseView.CourseViewOrder = updatedCourseView.CourseViewOrder;

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
        public async Task<int> GetMaxCourseViewOrder(int courseId)
        {
            var maxOrder = await _context.courseView!
                .Where(cv => cv.CourseId == courseId)
                .MaxAsync(cv => (int?)cv.CourseViewOrder) ?? 0;
            return maxOrder;
        }

        public async Task ChangeOrderCourseViews(int courseViewId)
        {
            var selectedCourseView = await _context.courseView!.FindAsync(courseViewId);
            if (selectedCourseView == null)
            {
                return;
            }

            var currentOrder = selectedCourseView.CourseViewOrder;

            var courseViewsToUpdate = await _context.courseView
                .Where(cv => cv.CourseId == selectedCourseView.CourseId && cv.CourseViewOrder > currentOrder)
                .ToListAsync();

            foreach (var cv in courseViewsToUpdate)
            {
                cv.CourseViewOrder--;
            }
            selectedCourseView.CourseViewOrder = await GetMaxCourseViewOrder(selectedCourseView.CourseId);
            await _context.SaveChangesAsync();
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Interfaces;
using CourseHouse.Data;
using CourseHouse.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class GradeRepository : IGradeRepository
    {
        private readonly ApplicationDbContext _context;

        public GradeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CourseGrade>> GetAllAsync()
        {
            return await _context.courseGrade!.Include(a => a.Course).Include(a => a.Author).ToListAsync();
        }

        public async Task<CourseGrade> GetByIdAsync(int id)
        {
            return await _context.courseGrade!.Include(a => a.Course).Include(a => a.Author).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<CourseGrade> CreateAsync(CourseGrade grade)
        {
            _context.courseGrade!.Add(grade);
            await _context.SaveChangesAsync();
            return grade;
        }

        public async Task<CourseGrade> UpdateAsync(int id, decimal updatedGrade)
        {
            var existingGrade = await _context.courseGrade!.FindAsync(id);

            if (existingGrade == null)
            {
                return null;
            }

            existingGrade.Grade = updatedGrade;

            await _context.SaveChangesAsync();
            return existingGrade;
        }

        public async Task<CourseGrade> DeleteAsync(int id)
        {
            var grade = await _context.courseGrade!.FindAsync(id);
            if (grade == null)
            {
                return null;
            }

            _context.courseGrade.Remove(grade);
            await _context.SaveChangesAsync();

            return grade;
        }
        public async Task<List<CourseGrade>> GetAllFromCourseAsync(int courseId)
        {
            var grades = await _context.courseGrade!.Include(c => c.Course).Include(c => c.Author).Where(c => c.CourseId == courseId).ToListAsync();
            return grades;
        }
    }
}

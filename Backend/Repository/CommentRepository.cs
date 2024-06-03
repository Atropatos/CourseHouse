using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Interfaces;
using CourseHouse.Data;
using CourseHouse.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CourseComment>> GetAllAsync()
        {
            return await _context.courseComment.Include(c => c.Author).Include(c => c.Course).ToListAsync();
        }

        public async Task<CourseComment> GetByIdAsync(int id)
        {
            return await _context.courseComment!.Include(c => c.Author).Include(c => c.Course).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<CourseComment> CreateAsync(CourseComment comment)
        {
            _context.courseComment!.Add(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<CourseComment> UpdateAsync(int id, string updatedComment)
        {
            var existingComment = await _context.courseComment!.FindAsync(id);

            if (existingComment == null)
            {
                return null;
            }

            existingComment.CommentContent = updatedComment;

            await _context.SaveChangesAsync();
            return existingComment;
        }

        public async Task<CourseComment> DeleteAsync(int id)
        {
            var comment = await _context.courseComment!.FindAsync(id);
            if (comment == null)
            {
                return null;
            }

            _context.courseComment.Remove(comment);
            await _context.SaveChangesAsync();

            return comment;
        }

        public async Task<List<CourseComment>> GetAllFromCourseAsync(int courseId)
        {
            var comments = await _context.courseComment!.Include(c => c.Course).Include(c => c.Author).Where(c => c.CourseId == courseId).ToListAsync();
            return comments;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseHouse.Models;

namespace Backend.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<CourseComment>> GetAllAsync();
        Task<List<CourseComment>> GetAllFromCourseAsync(int courseId);
        Task<CourseComment> GetByIdAsync(int id);
        Task<CourseComment> DeleteAsync(int id);
        Task<CourseComment> UpdateAsync(int id, string updatedComment);
        Task<CourseComment> CreateAsync(CourseComment comment);
    }
}
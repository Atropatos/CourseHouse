using CourseHouse.Data;
using CourseHouse.Models;

namespace CoursesHouse.Interfaces
{
    public interface ICourseViewRepository
    {
        Task<List<CourseView>> GetAllAsync();

        Task<CourseView> GetByIdAsync(int id);
        Task<CourseView> DeleteAsync(int id);
        Task<CourseView> UpdateAsync(int id, CourseView updatedCourseView);
        Task<CourseView> CreateAsync(CourseView courseView);
    }
}

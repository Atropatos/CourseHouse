using CourseHouse.Data;
using CourseHouse.Models;

namespace CoursesHouse.Interfaces
{
    public interface ICourseViewRepository
    {

        Task<CourseView> CreateAsync(CourseView courseView);

        Task<List<CourseView>> getAllAsync();
        Task<CourseView> GetByIdAsync(int id);
    }
}

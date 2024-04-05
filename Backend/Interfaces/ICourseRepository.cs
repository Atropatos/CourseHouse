using CourseHouse.Models;

namespace CoursesHouse.Interfaces
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllAsync();
    }
}

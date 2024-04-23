using CourseHouse.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoursesHouse.Interfaces
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllAsync();

        Task<Course> GetByIdAsync(int id);
        Task<Course> DeleteAsync( int id);
        Task<Course> UpdateAsync( int id,  Course updatedCourse);
        Task<Course> CreateAsync( Course course);
       
    }
}

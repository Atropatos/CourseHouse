using CourseHouse.Models;

namespace CoursesHouse.Interfaces
{
    public interface IPictureRepository
    {
        Task<List<Picture>> GetAllAsync();
        Task<Picture> CreateAsync(Picture picture);

    }
}

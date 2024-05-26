using CourseHouse.Models;

namespace CoursesHouse.Interfaces
{
    public interface IContentRepository
    {
         Task<Content> CreateAsync(Content content);
        Task<List<Content>> getAllAsync();
    }
}

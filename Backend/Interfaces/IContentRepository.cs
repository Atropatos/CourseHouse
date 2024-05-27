using CourseHouse.Models;

namespace CoursesHouse.Interfaces
{
    public interface IContentRepository
    {
        Task<List<Content>> GetAllAsync();
        Task<Content> GetByIdAsync(int id);
        Task<Content> DeleteAsync(int id);
        Task<Content> UpdateAsync(int id, Content updatedContent);
        Task<Content> CreateAsync(Content content);
        Task<int> GetMaxContentOrder(int courseViewId);
        Task ChangeOrderContent(int contentId);
    }
}

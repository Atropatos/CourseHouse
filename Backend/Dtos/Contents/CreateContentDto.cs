using Backend.Models.ContentModels;
using CourseHouse.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CoursesHouse.Dtos.Contents
{
    public class CreateContentDto
    {
        public int CourseViewId { get; set; }
        public string Text { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string ContentUrl { get; set; } = string.Empty;
        public bool Correct { get; set; } = false;
        public ContentType ContentType { get; set; } = ContentType.Text;
    }
}

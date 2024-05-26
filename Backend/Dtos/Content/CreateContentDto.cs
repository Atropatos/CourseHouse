using CourseHouse.Models;

namespace CoursesHouse.Dtos.Content
{
    public class CreateContentDto
    {
        
       // public Course Course { get; set; }

        public int Order { get; set; }

        public int CourseViewId { get; set; }
       // public CourseView CourseView { get; set; }

       
        public string Text { get; set; } = string.Empty;
    }
}

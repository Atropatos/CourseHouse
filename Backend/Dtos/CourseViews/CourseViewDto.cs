using CourseHouse.Models;
using CoursesHouse.Dtos.Courses;
namespace CoursesHouse.Dtos.CourseViews
{
    public class CourseViewDto
    {
        public int ViewId { get; set; }

        public CourseHouse.Models.Course Course { get; set; } = new CourseHouse.Models.Course();
        public int CourseViewOrder { get; set; }

        public List<CourseHouse.Models.Content> Content { get; set; } = new List<CourseHouse.Models.Content>();
    }
}

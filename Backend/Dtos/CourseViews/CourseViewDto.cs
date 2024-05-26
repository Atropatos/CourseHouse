using CourseHouse.Models;
using CoursesHouse.Dtos.Courses;
namespace CoursesHouse.Dtos.CourseViews
{
    public class CourseViewDto
    {
        public int ViewId { get; set; }

        public CourseHouse.Models.Course Course { get; set; } = new CourseHouse.Models.Course();

        public List<CourseHouse.Models.Content> Content { get; set; } = new List<CourseHouse.Models.Content>();
        public List<Picture> Pictures { get; set; } = new List<Picture>();
        public List<Video> Videos { get; set; } = new List<Video>();
        public List<TestAnswer> TestAnswers { get; set; } = new List<TestAnswer>();
    }
}

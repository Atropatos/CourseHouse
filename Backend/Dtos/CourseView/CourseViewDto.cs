using CourseHouse.Models;

namespace CoursesHouse.Dtos.CourseView
{
    public class CourseViewDto
    {
        public int ViewId { get; set; }

       // public int CourseId { get; set; }

        public List<CourseHouse.Models.Content> Content { get; set; } = new List<CourseHouse.Models.Content>();
        public List<Picture> Pictures { get; set; } = new List<Picture>();
        public List<Video> Videos { get; set; } = new List<Video>();
        public List<TestAnswer> TestAnswers { get; set; } = new List<TestAnswer>();
    }
}

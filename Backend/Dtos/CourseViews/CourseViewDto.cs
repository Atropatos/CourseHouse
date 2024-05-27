using Backend.Dtos.Contents;
using CourseHouse.Models;
using CoursesHouse.Dtos.Courses;
namespace CoursesHouse.Dtos.CourseViews
{
    public class CourseViewDto
    {
        public int ViewId { get; set; }

        public CourseDto CourseDto { get; set; } = new CourseDto();
        public int CourseViewOrder { get; set; }

        public List<ContentDto> Content { get; set; } = new List<ContentDto>();
    }
}

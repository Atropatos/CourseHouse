using Backend.Dtos.Contents;
using Backend.Dtos.Courses;
using CourseHouse.Models;
using CoursesHouse.Dtos.Courses;
namespace CoursesHouse.Dtos.CourseViews
{
    public class CourseViewDto
    {
        public int ViewId { get; set; }

        public SimpleCourseDto SimpleCourseDto { get; set; } = new SimpleCourseDto();
        public int CourseViewOrder { get; set; }

        public List<ContentDto> Content { get; set; } = new List<ContentDto>();
    }
}

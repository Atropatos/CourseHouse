
using CourseHouse.Models;
using CoursesHouse.Dtos.CourseViews;
namespace CoursesHouse.Mappers
{
    public static class CourseViewMapper
    {

        public static CourseViewDto ToCourseViewDto(this CourseView courseView)
        {
            return new CourseViewDto
            {
                ViewId = courseView.ViewId,
                Course = courseView.Course,
                Content = courseView.Content,
                Pictures = courseView.Pictures,
                Videos = courseView.Videos,
                TestAnswers = courseView.TestAnswers
            };
        }

        public static CourseView ToCourseFromCreate(this CreateCourseViewDto courseDto)
        {
            return new CourseView
            {
                CourseId = courseDto.CourseId,
            };
        }
    }
}

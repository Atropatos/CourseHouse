
using CourseHouse.Models;
using CoursesHouse.Dtos.Courses;
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
                Course = new Course
                {
                    CourseId = courseView.Course.CourseId,
                    CourseName = courseView.Course.CourseName,
                    CoursePrice = courseView.Course.CoursePrice,
                    CourseDescription = courseView.Course.CourseDescription,
                },
                Content = courseView.Content,
                CourseViewOrder = courseView.CourseViewOrder
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

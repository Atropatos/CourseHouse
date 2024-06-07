
using Backend.Dtos.Contents;
using Backend.Dtos.CourseViews;
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
                SimpleCourseDto = courseView.Course.ToSimpleCourseDto(),
                Content = courseView.Content.Select(a => a.ToContentDto()).ToList(),
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

        public static SimpleCourseViewDto ToSimpleCourseViewDto(this CourseView courseView)
        {
            return new SimpleCourseViewDto
            {
                ViewId = courseView.ViewId,
                CourseDto = courseView.Course.ToSimpleCourseDto(),
                CourseViewOrder = courseView.CourseViewOrder
            };
        }
    }
}

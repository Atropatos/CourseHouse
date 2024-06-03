
using Backend.Dtos.Contents;
using CourseHouse.Models;
using CoursesHouse.Dtos.Courses;
using CoursesHouse.Dtos.CourseViews;
namespace CoursesHouse.Mappers
{
    public static class CourseViewMapper
    {

        public static CourseViewDto ToCourseViewDto(this CourseView courseView)
        {
            var temp = courseView.Course.ToCourseDto();
            temp.CourseViews = new List<CourseViewDto>();


            return new CourseViewDto
            {
                ViewId = courseView.ViewId,
                CourseDto = temp,
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
    }
}


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
            temp.CourseViews = new List<CourseView>();
            return new CourseViewDto
            {
                ViewId = courseView.ViewId,
                CourseDto = temp,
                Content = courseView.Content.Select(content => new ContentDto
                {
                    ContentId = content.ContentId,
                    Order = content.Order,
                    CourseViewId = content.CourseViewId,
                    Title = content.Title,
                    Text = content.Text,
                    ContentUrl = content.ContentUrl,
                    Correct = content.Correct,
                    ContentType = content.ContentType
                }).ToList(),
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

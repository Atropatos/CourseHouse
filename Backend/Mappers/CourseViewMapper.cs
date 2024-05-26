
using CoursesHouse.Dtos.CourseView;
using CourseHouse.Models;
namespace CoursesHouse.Mappers
{
    public static class CourseViewMapper
    {

        public static CourseViewDto ToCourseViewDto(this CourseView courseView)
        {
            return new CourseViewDto
            {
                ViewId = courseView.ViewId,
               // CourseId = courseView.CourseId,
                Content = courseView.Content,
                Pictures = courseView.Pictures,
                Videos = courseView.Videos,
                TestAnswers = courseView.TestAnswers
            };
        }
    }
}

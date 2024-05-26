using CourseHouse.Models;
using CoursesHouse.Dtos.Contents;

namespace CoursesHouse.Mappers
{
    public static class ContentMapper
    {

        public static Content ToContentFromCreate(this CreateContentDto contentDto, int courseId)
        {
            return new Content
            {

                Order = contentDto.Order,
                CourseViewId = contentDto.CourseViewId,
                Text = contentDto.Text,
            };
        }
    }
}

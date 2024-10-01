using CourseHouse.Models;
using CoursesHouse.Dtos.Contents;

namespace CoursesHouse.Mappers
{
    public static class ContentMapper
    {

        public static Content ToContentDto(this Content content)
        {
            return new Content
            {
                ContentId = content.ContentId,
                Order = content.Order,
                CourseViewId = content.CourseViewId,
                Title = content.Title,
                Text = content.Text,
                ContentUrl = content.ContentUrl,
                Correct = content.Correct,
                ContentType = content.ContentType
            };
        }

        public static Content ToContentFromCreate(this CreateContentDto contentDto)
        {
            return new Content
            {
                CourseViewId = contentDto.CourseViewId,
                Text = contentDto.Text,
                Title = contentDto.Title,
                ContentUrl = contentDto.ContentUrl,
                Correct = contentDto.Correct,
                ContentType = contentDto.ContentType
            };
        }
    }
}

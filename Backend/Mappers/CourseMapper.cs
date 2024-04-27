using CourseHouse.Models;
using CoursesHouse.Dtos.Course;

namespace CoursesHouse.Mappers
{
    public static class CourseMapper
    {
        public static CourseDto ToCourseDto(this Course courseModel)
        {
            return new CourseDto
            {
                CourseId = courseModel.CourseId,
                CourseName = courseModel.CourseName,
                CoursePrice = courseModel.CoursePrice,
                CreatedBy = courseModel.User.UserName
            };
        }

        public static Course ToCourseFromCreate(this CreateCourseDto courseDto)
        {
            return new Course
            {
                CourseName = courseDto.CourseName,
                CoursePrice = courseDto.CoursePrice
            };




        }
    }
}

    
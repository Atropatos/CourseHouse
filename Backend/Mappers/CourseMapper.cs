using Backend.Mappers;
using Backend.Models.CourseModels;
using CourseHouse.Models;
using CoursesHouse.Dtos.Courses;
using CoursesHouse.Dtos.Courses;
using CoursesHouse.Dtos.CourseViews;
using CoursesHouse.Interfaces;

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
                CreatedBy = courseModel.User.UserName,
                CourseDescription = courseModel.CourseDescription,
                CourseCategories = courseModel.CourseCategoryMappings.Select(mapping => new CourseCategory
                {
                    CategoryId = mapping.CourseCategory.CategoryId,
                    CategoryName = mapping.CourseCategory.CategoryName
                }).ToList(),
                EnrolledUsers = courseModel.EnrolledUsers.Select(a => a.ToUserDto()).ToList(),
                Comments = courseModel.Comments.Select(a => a.ToCommentDto()).ToList(),
                Grades = courseModel.Grades.Select(a => a.ToGradeDto()).ToList(),
                CourseViews = courseModel.CourseViews.Select(a => a.ToCourseViewDto()).ToList()
            };
        }

        public static Course ToCourseFromCreate(this CreateCourseDto courseDto)
        {
            return new Course
            {
                CourseName = courseDto.CourseName,
                CoursePrice = courseDto.CoursePrice,
                CourseDescription = courseDto.CourseDescription,
            };
        }
    }
}
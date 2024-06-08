using Backend.Dtos;
using Backend.Dtos.Courses;
using Backend.Dtos.UserDtos;
using Backend.Mappers;
using Backend.Models.CourseModels;
using CourseHouse.Models;
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
                CreatedBy = courseModel.User?.UserName ?? "Unknown",
                CourseDescription = courseModel.CourseDescription,
                CourseCategories = courseModel.CourseCategoryMappings?
            .Select(mapping => new CourseCategory
            {
                CategoryId = mapping.CourseCategory.CategoryId,
                CategoryName = mapping.CourseCategory.CategoryName
            }).ToList() ?? new List<CourseCategory>(),
                EnrolledUsers = courseModel.EnrolledUsers?.Select(a => a.ToSimpleUserDto()).ToList() ?? new List<SimpleUserDto>(),
                Comments = courseModel.Comments != null ? courseModel.Comments.Select(a => a.ToCommentDto()).ToList() : new List<CommentDto>(),
                Grades = courseModel.Grades != null ? courseModel.Grades.Select(a => a.ToGradeDto()).ToList() : new List<GradeDto>(),
                CourseViews = courseModel.CourseViews?.Select(a => a.ToCourseViewDto()).ToList() ?? new List<CourseViewDto>()
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

        public static SimpleCourseDto ToSimpleCourseDto(this Course courseModel)
        {
            return new SimpleCourseDto
            {
                CourseId = courseModel.CourseId,
                CourseName = courseModel.CourseName,
                CoursePrice = courseModel.CoursePrice,
                CourseDescription = courseModel.CourseDescription
            };
        }
    }
}
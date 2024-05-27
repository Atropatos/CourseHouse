using Backend.Models.CourseModels;
using CourseHouse.Models;
using CoursesHouse.Dtos.Course;
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
                EnrolledUsers = courseModel.EnrolledUsers.Select(user => new User
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email
                }).ToList(),
                Comments = courseModel.Comments.Select(comment => new CourseComment
                {
                    CourseCommentId = comment.CourseCommentId,
                    CommentContent = comment.CommentContent,
                    Author = comment.Author
                }).ToList(),
                Grades = courseModel.Grades.Select(grade => new CourseGrade
                {
                    CourseGradeId = grade.CourseGradeId,
                    Grade = grade.Grade,
                    Author = grade.Author
                }).ToList(),
                CourseViews = courseModel.CourseViews.Select(view => new CourseView
                {
                    ViewId = view.ViewId,
                    CourseViewOrder = view.CourseViewOrder,
                    CourseId = view.CourseId,
                    Content = view.Content.Select(content => new Content
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
                }).ToList()
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
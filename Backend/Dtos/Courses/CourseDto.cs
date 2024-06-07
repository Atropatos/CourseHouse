using CourseHouse.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Backend.Models.CourseModels;
using Backend.Dtos.Courses;
using CoursesHouse.Dtos.CourseViews;
using Backend.Dtos;

namespace CoursesHouse.Dtos.Courses
{
    public class CourseDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public decimal CoursePrice { get; set; } = new Decimal(0);
        public string CreatedBy { get; set; } = string.Empty;
        public string CourseDescription { get; set; } = string.Empty;

        public List<CourseCategory> CourseCategories { get; set; } = new List<CourseCategory>();

        public List<UserDto> EnrolledUsers { get; set; } = new List<UserDto>();
        public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
        public List<GradeDto> Grades { get; set; } = new List<GradeDto>();
        public List<CourseViewDto> CourseViews { get; set; } = new List<CourseViewDto>();
    }
}

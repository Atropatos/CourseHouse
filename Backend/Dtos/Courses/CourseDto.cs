using CourseHouse.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Backend.Models.CourseModels;

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

        public List<User> EnrolledUsers { get; set; } = new List<User>();
        public List<CourseComment> Comments { get; set; } = new List<CourseComment>();
        public List<CourseGrade> Grades { get; set; } = new List<CourseGrade>();
        public List<CourseView> CourseViews { get; set; } = new List<CourseView>();
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Models.CourseModels;

namespace CourseHouse.Models
{
    [Table("Courses")]
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Course name is required.")]
        public string CourseName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Course price is required.")]

        [Column(TypeName = "decimal(18,2)")]
        public decimal CoursePrice { get; set; } = new Decimal(0);

        [Required(ErrorMessage = "Course description is required.")]
        public string CourseDescription { get; set; } = string.Empty;
        public string UserId { get; set; }
        public User User { get; set; }

        public List<CourseCategoryMapping> CourseCategoryMappings { get; set; } = new List<CourseCategoryMapping>();
        public List<User> EnrolledUsers { get; set; } = new List<User>();
        public List<CourseComment> Comments { get; set; } = new List<CourseComment>();
        public List<CourseGrade> Grades { get; set; } = new List<CourseGrade>();
        public List<CourseView> CourseViews { get; set; } = new List<CourseView>();
        public List<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseHouse.Models
{
    [Table("Courses")]
    public class Course
    {   
        [Key]
        public int CourseId { get; set; }

        [ForeignKey("Author")]
        [Required(ErrorMessage = "Author is required.")]
        public int UserId { get; set; }
        public User Author { get; set; }

        [Required(ErrorMessage = "Course name is required.")]
        public string CourseName { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal CoursePrice { get; set; } = new Decimal(0);

        public List<User> EnrolledUsers { get; set; } = new List<User>();
        public List<CourseComment> Comments { get; set; } = new List<CourseComment>();
        public List<CourseGrade> Grades { get; set; } = new List<CourseGrade>();
        public List<CourseView> CourseViews { get; set; } = new List<CourseView>();
    }
}

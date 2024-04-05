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
        public User User { get; set; }

        [Required(ErrorMessage = "Course name is required.")]
        public string CourseName { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal CoursePrice { get; set; } = new Decimal(0);

        public List<User> EnrolledUsers { get; set; } = new List<User>();

        public List<CourseComment> Comments { get; set; } = new List<CourseComment>();

        //views and tests that should be seen one after other
        //we store here their order for easy access
        public List<int> CourseFlow { get; set; } = new List<int>();
        public List<CourseView> CourseViews { get; set; } = new List<CourseView>();
        public List<ViewTest> ViewsTests { get; set; } = new List<ViewTest>();
    }
}

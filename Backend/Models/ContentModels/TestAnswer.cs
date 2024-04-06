using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CourseHouse.Models;

namespace CourseHouse.Models
{
    [Table("TestAnswers")]
    public class TestAnswer
    {
        [Key]
        public int TestAnswerId { get; set; }

        [Required]
        [ForeignKey("Author")]
        public int UserId { get; set; }
        public User Author { get; set; }

        [Required]
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int Order { get; set; }

        [Required]
        [ForeignKey("CourseView")]
        public int CourseViewId { get; set; }
        public CourseView CourseView { get; set; }

        [Required(ErrorMessage = "Answer content is required.")]
        [Range(3, 100, ErrorMessage = "Answer must be in 3 to 100 characters.")]
        public string Content { get; set; }

        [Required]
        public bool correct { get; set; }
    }
}

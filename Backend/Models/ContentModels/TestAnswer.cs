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

        [Required(ErrorMessage = "Answer content is required.")]
        [Range(3, 100, ErrorMessage = "Answer must be in 3 to 100 characters.")]
        public string content { get; set; }

        [Required]
        public bool correct { get; set; }

        [ForeignKey("ViewTest")]
        public int ViewTestId { get; set; }

    }
}

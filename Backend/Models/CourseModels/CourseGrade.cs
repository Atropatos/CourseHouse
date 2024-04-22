using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CourseHouse.Models;

namespace CourseHouse.Models
{
    [Table("CourseGrades")]
    public class CourseGrade
    {
        [Key]
        public int CourseGradeId { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        [ForeignKey("User")]
        public string id { get; set; }
        public User Author { get; set; }

        [Column(TypeName = "decimal(2,2)")]
        [Range(0.0, 10.0, ErrorMessage = "Grade must be between 0.0 to 10.0")]
        public decimal Grade { get; set; }
    }
}

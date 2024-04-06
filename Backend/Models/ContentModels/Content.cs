using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseHouse.Models
{

    [Table("Contents")]
    public class Content
    {
        [Key]
        public int ContentId { get; set; }

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

        [Required(ErrorMessage = "Content is required.")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; } = string.Empty;
    }
}

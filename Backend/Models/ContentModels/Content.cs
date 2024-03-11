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
        public User User { get; set; }

        [Required(ErrorMessage = "Content is required.")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; } = string.Empty;
    }
}

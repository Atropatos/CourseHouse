using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CourseHouse.Models;

namespace CourseHouse.Models
{
    [Table("Videos")]
    public class Video
    {
        [Key]
        public int VideoId { get; set; }

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

        [Required]
        [Url(ErrorMessage = "Incorrect URL format.")]
        [StringLength(255, ErrorMessage = "URL length must not exceed 255 characters.")]
        public string ContentUrl { get; set; } = string.Empty;
    }
}

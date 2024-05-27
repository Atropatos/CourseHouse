using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;
using Backend.Models.ContentModels;

namespace CourseHouse.Models
{

    [Table("Contents")]
    public class Content
    {
        [Key]
        public int ContentId { get; set; }
        public int Order { get; set; }

        [ForeignKey("CourseView")]
        public int CourseViewId { get; set; }
        public CourseView CourseView { get; set; }

        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage = "Content is required.")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; } = string.Empty;
        public string ContentUrl { get; set; } = string.Empty;
        public bool Correct { get; set; }
        public Backend.Models.ContentModels.ContentType ContentType { get; set; }
    }
}
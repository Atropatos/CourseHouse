using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CourseHouse.Models;

namespace CourseHouse.Models
{
    [Table("CourseViews")]
    public class CourseView
    {
        [Key]
        public int ViewId { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public List<int> ContentOrder { get; set; } = new List<int>();

        public List<Content> Content { get; set; } = new List<Content>();

        public List<Picture> Pictures { get; set; } = new List<Picture>();

        public List<Video> Videos { get; set; } = new List<Video>();
    }
}

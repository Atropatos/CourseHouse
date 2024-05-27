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
        //new orders
        public int CourseViewOrder { get; set; }

        public List<Content> Content { get; set; } = new List<Content>();
    }
}

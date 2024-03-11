using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CourseHouse.Models;

namespace CourseHouse.Models
{
    [Table("ViewTests")]
    public class ViewTest
    {
        [Key]
        public int TestId { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public List<int> ContentOrder { get; set; } = new List<int>();

        public List<Content> Content { get; set; } = new List<Content>();

        public List<Picture> Pictures { get; set; } = new List<Picture>();

        public List<Video> Videos { get; set; } = new List<Video>();

        public List<TestAnswer> TestAnswers { get; set; } = new List<TestAnswer>();
    }
}

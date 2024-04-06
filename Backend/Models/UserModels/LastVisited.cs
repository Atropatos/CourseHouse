using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseHouse.Models
{
    [Table("LastVisited")]
    public class LastVisited
    {
        [Key]
        public int LastVisitedId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        public List<int> LastVisitedCourses { get; set; } = new List<int>();

        [DataType(DataType.DateTime)]
        public DateTime LastVisitedTime { get; set; } = DateTime.Now;
    }
}

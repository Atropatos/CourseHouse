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
        public int LastVisitedCourse { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CourseHouse.Models;

namespace CourseHouse.Models
{
    [Table("Purchases")]
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        [ForeignKey("User")]
        public string id { get; set; }
        public User User { get; set; }

        [ForeignKey("CreditCard")]
        public int CreditCardId { get; set; }
        public CreditCard CereditCard { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime PurchasedOn { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalSpend { get; set; }

        public List<Course> PurachasedCourses { get; set; } = new List<Course>();
    }
}

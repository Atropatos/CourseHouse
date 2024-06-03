using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CourseHouse.Models;
using Microsoft.AspNetCore.Identity;

namespace CourseHouse.Models
{
    [Table("Users")]
    public class User : IdentityUser
    {
        public List<Purchase> UserPurchases { get; set; } = new List<Purchase>();
        public List<CreditCard> UserCreditCards { get; set; } = new List<CreditCard>();
        public List<Course> CreatedCourses { get; set; } = new List<Course>();
        public List<CourseComment> Comments { get; set; } = new List<CourseComment>();
        public List<CourseGrade> Grades { get; set; } = new List<CourseGrade>();
    }
}
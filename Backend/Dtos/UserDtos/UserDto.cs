using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseHouse.Models;

namespace Backend.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Emial { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
        public List<Purchase> UserPurchases { get; set; } = new List<Purchase>();
        public List<CreditCard> UserCreditCards { get; set; } = new List<CreditCard>();
        public List<Course> CreatedCourses { get; set; } = new List<Course>();
    }
}
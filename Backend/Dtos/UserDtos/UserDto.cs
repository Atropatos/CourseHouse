using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos.Courses;
using CourseHouse.Models;
using CoursesHouse.Dtos.Courses;

namespace Backend.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Emial { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
        public List<Purchase> UserPurchases { get; set; } = new List<Purchase>();
        public List<CreditCard> UserCreditCards { get; set; } = new List<CreditCard>();
        public List<CourseDto> CreatedCourses { get; set; } = new List<CourseDto>();
        public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
        public List<GradeDto> Grades { get; set; } = new List<GradeDto>();
    }
}
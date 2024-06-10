using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.CourseModels;

namespace Backend.Dtos.Courses
{
    public class SimpleCourseDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public decimal CoursePrice { get; set; } = new Decimal(0);
        public string CourseDescription { get; set; } = string.Empty;
        public List<CourseCategory> CourseCategories { get; set; } = new List<CourseCategory>();
    }
}
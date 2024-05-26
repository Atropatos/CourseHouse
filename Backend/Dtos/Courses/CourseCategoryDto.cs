using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dtos.Course
{
    public class CourseCategoryDto
    {
        public int CourseCategoryId { get; set; }
        public string CourseCategoryName { get; set; } = string.Empty;
    }
}
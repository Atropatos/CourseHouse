using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dtos.Courses
{
    public class GradeCreateDto
    {
        public int CourseId { get; set; }
        public decimal Grade { get; set; }
    }
}
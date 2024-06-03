using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dtos.Courses
{
    public class GradeDto
    {
        public string Course { get; set; }
        public string Author { get; set; }
        public decimal Grade { get; set; }
    }
}
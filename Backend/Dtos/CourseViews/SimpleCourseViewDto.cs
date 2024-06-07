using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos.Courses;

namespace Backend.Dtos.CourseViews
{
    public class SimpleCourseViewDto
    {
        public int ViewId { get; set; }

        public SimpleCourseDto CourseDto { get; set; } = new SimpleCourseDto();
        public int CourseViewOrder { get; set; }
    }
}
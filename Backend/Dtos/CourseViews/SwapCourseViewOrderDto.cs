using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dtos.CourseViews
{
    public class SwapCourseViewOrderDto
    {
        [Required]
        public int CourseViewId1 { get; set; }

        [Required]
        public int CourseViewId2 { get; set; }
    }
}
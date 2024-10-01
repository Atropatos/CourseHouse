using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CourseHouse.Models;

namespace Backend.Models.CourseModels
{
    [Table("CourseCategoryMapping")]
    public class CourseCategoryMapping
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int CategoryId { get; set; }
        public CourseCategory CourseCategory { get; set; }
    }
}
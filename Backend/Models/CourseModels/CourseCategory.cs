using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.CourseModels
{
    [Table("CourseCategories")]
    public class CourseCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public List<CourseCategoryMapping> CourseCategoryMappings { get; set; } = new List<CourseCategoryMapping>();

        internal bool Any(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
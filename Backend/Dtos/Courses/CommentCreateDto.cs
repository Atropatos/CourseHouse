using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dtos.Courses
{
    public class CommentCreateDto
    {
        public int CourseId { get; set; }
        public string CommentContent { get; set; } = string.Empty;
    }
}
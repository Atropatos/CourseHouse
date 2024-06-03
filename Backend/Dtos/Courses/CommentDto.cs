using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dtos.Courses
{
    public class CommentDto
    {
        public int CommmentId { get; set; }
        public string CourseName { get; set; }
        public string AuthorName { get; set; }
        public string CommentContent { get; set; }
    }
}
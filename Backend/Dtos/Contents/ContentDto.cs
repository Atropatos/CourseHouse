using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dtos.Contents
{
    public class ContentDto
    {
        public int ContentId { get; set; }
        public int Order { get; set; }
        public int CourseViewId { get; set; }
        public string Text { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string ContentUrl { get; set; } = string.Empty;
        public bool Correct { get; set; } = false;
        public Backend.Models.ContentModels.ContentType ContentType { get; set; } = Models.ContentModels.ContentType.Text;
    }
}
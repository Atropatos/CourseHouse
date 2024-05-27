using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dtos.UserTestAnswers
{
    public class UserTestAnswerDto
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int ContentTest { get; set; }
        public string UserId { get; set; }
        public int AnswerId { get; set; }
        public bool IsCorrect { get; set; }
    }
}
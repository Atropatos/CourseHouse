using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.UserModels
{
    [Table("UserTestAnswers")]
    public class UserTestAnswer
    {
        [Key]
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int TestId { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public bool IsCorrect { get; set; }
    }
}
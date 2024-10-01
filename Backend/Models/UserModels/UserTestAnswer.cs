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

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        [ForeignKey("Content")]
        public int ContentTest { get; set; }

        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }

        [ForeignKey("Content")]
        public int AnswerId { get; set; }

        public bool IsCorrect { get; set; }
    }
}
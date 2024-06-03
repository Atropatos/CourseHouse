using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos.Courses;
using CourseHouse.Models;

namespace Backend.Mappers
{
    public static class GradeMapper
    {
        public static GradeDto ToGradeDto(this CourseGrade grade)
        {
            return new GradeDto
            {
                Course = grade.Course.CourseName,
                Author = grade.Author.UserName,
                Grade = grade.Grade
            };
        }

        public static CourseGrade ToGradeFromCreate(this GradeCreateDto gradeDto)
        {
            return new CourseGrade
            {
                CourseId = gradeDto.CourseId,
                Grade = gradeDto.Grade
            };
        }
    }
}
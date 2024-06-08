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
            if (grade == null)
            {
                throw new ArgumentNullException(nameof(grade));
            }

            return new GradeDto
            {
                Course = grade.Course?.CourseName ?? "Unknown Course",
                Author = grade.Author?.UserName ?? "Unknown Author",
                Grade = grade.Grade
            };
        }

        public static CourseGrade ToGradeFromCreate(this GradeCreateDto gradeDto)
        {
            if (gradeDto == null)
            {
                throw new ArgumentNullException(nameof(gradeDto));
            }
            return new CourseGrade
            {
                CourseId = gradeDto.CourseId,
                Grade = gradeDto.Grade
            };
        }
    }
}
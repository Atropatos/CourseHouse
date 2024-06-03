using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos.Courses;
using Backend.Models.CourseModels;

namespace Backend.Mappers
{
    public static class CourseCategoryMapper
    {
        public static CourseCategoryDto ToCourseCategoryDto(this CourseCategory category)
        {
            return new CourseCategoryDto
            {
                CourseCategoryId = category.CategoryId,
                CourseCategoryName = category.CategoryName
            };
        }

        public static CourseCategory ToCourseCategoryFromCreate(this CreateCourseCategoryDto courseDto)
        {
            return new CourseCategory
            {
                CategoryName = courseDto.CourseCategoryName
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos.Courses;
using CourseHouse.Models;

namespace Backend.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this CourseComment comment)
        {
            return new CommentDto
            {
                CommmentId = comment.Id,
                CourseName = comment.Course.CourseName,
                AuthorName = comment.Author.UserName,
                CommentContent = comment.CommentContent
            };
        }

        public static CourseComment ToCommentFromCreate(this CommentCreateDto commentDto)
        {
            return new CourseComment
            {
                CourseId = commentDto.CourseId,
                CommentContent = commentDto.CommentContent
            };
        }
    }
}
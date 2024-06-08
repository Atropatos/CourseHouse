using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos;
using Backend.Dtos.Courses;
using Backend.Dtos.UserDtos;
using CourseHouse.Models;
using CoursesHouse.Mappers;

namespace Backend.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Emial = user.Email,
                Roles = new List<string>(),
                UserPurchases = user.UserPurchases,
                UserCreditCards = user.UserCreditCards,
                CreatedCourses = user.CreatedCourses != null ? user.CreatedCourses.Select(a => a.ToSimpleCourseDto()).ToList() : new List<SimpleCourseDto>(),
                Comments = user.Comments != null ? user.Comments.Select(a => a.ToCommentDto()).ToList() : new List<CommentDto>(),
                Grades = user.Grades != null ? user.Grades.Select(a => a.ToGradeDto()).ToList() : new List<GradeDto>(),
            };
        }

        public static User ToUser(this UserDto userDto)
        {
            return new User
            {
                Id = userDto.Id,
                UserName = userDto.UserName,
                Email = userDto.Emial,
            };
        }

        public static User ToUserFromUserUpdatedDto(this UserUpdateDto userUpdateDto)
        {
            return new User
            {
                UserName = userUpdateDto.UserName,
                Email = userUpdateDto.Email
            };
        }
        public static SimpleUserDto ToSimpleUserDto(this User user)
        {
            return new SimpleUserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Emial = user.Email
            };
        }
    }
}
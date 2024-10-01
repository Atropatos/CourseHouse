using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos.UserTestAnswers;
using Backend.Models.UserModels;

namespace Backend.Mappers
{
    public static class UserTestAnswersMapper
    {
        public static UserTestAnswerDto ToUserTestAnswerDto(this UserTestAnswer userTestAnswer)
        {
            return new UserTestAnswerDto
            {
                Id = userTestAnswer.Id,
                CourseId = userTestAnswer.CourseId,
                ContentTest = userTestAnswer.ContentTest,
                UserId = userTestAnswer.UserId,
                AnswerId = userTestAnswer.AnswerId,
                IsCorrect = userTestAnswer.IsCorrect
            };
        }

        public static UserTestAnswer ToUserTestAnswerFromCreate(this UserTestAnswerCreateDto userTestAnswerCreateDto)
        {
            return new UserTestAnswer
            {
                ContentTest = userTestAnswerCreateDto.ContentTest,
                AnswerId = userTestAnswerCreateDto.AnswerId,
            };
        }
    }
}
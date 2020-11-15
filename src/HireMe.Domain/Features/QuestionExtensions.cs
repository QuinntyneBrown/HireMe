using HireMe.Core.Models;
using HireMe.Domain.Features.Questions;

namespace HireMe.Domain.Features
{
    public static class QuestionExtensions
    {
        public static QuestionDto ToDto(this Question question)
        {
            return new QuestionDto
            {
                QuestionId = question.QuestionId,
            };
        }
    }
}

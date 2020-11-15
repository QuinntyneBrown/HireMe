using HireMe.Core.Models;
using HireMe.Domain.Features.Answers;

namespace HireMe.Domain.Features
{
    public static class AnswerExtensions
    {
        public static AnswerDto ToDto(this Answer answer)
        {
            return new AnswerDto
            {
                AnswerId = answer.AnswerId,
            };
        }
    }
}

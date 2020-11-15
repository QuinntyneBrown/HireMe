using System;

namespace HireMe.Domain.Features.Questions
{
    public class QuestionDto
    {
        public Guid QuestionId { get; set; }
        public Guid OpportunityId { get; set; }
        public string Body { get; set; }
        public int? SortOrder { get; set; }
    }
}

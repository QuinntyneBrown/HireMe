using HireMe.Domain.Features.Questions;
using System;
using System.Collections.Generic;

namespace HireMe.Domain.Features.Opportunities
{
    public class OpportunityDto
    {
        public Guid OpportunityId { get; set; }
        public string Name { get; set; }
        public Guid EmployeerId { get; set; }
        public ICollection<QuestionDto> Questions { get; set; } = new HashSet<QuestionDto>();
    }
}

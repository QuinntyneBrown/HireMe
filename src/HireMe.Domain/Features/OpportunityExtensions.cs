using HireMe.Core.Models;
using HireMe.Domain.Features.Opportunities;
using System.Linq;

namespace HireMe.Domain.Features
{
    public static class OpportunityExtensions
    {
        public static OpportunityDto ToDto(this Opportunity opportunity)
        {
            return new OpportunityDto
            {
                OpportunityId = opportunity.OpportunityId,
                Name = opportunity.Name,
                EmployeerId = opportunity.EmployeerId,
                Questions = opportunity.Questions.Select(x => x.ToDto()).ToList()
            };
        }
    }
}

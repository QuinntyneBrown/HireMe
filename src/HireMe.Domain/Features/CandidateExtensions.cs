using HireMe.Core.Models;
using HireMe.Domain.Features.Candidates;

namespace HireMe.Domain.Features
{
    public static class CandidateExtensions
    {
        public static CandidateDto ToDto(this Candidate candidate)
        {
            return new CandidateDto
            {
                CandidateId = candidate.CandidateId,
            };
        }
    }
}

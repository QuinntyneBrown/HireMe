using HireMe.Core.Models;

namespace HireMe.TestUtilities.Builders
{
    public class CandidateBuilder
    {
        private Candidate _candidate;

        public CandidateBuilder()
        {
            _candidate = new Candidate();
        }

        public Candidate Build()
        {
            return _candidate;
        }
    }
}

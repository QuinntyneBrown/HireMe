using HireMe.Core.Models;

namespace HireMe.TestUtilities.Builders
{
    public class OpportunityBuilder
    {
        private Opportunity _opportunity;

        public OpportunityBuilder()
        {
            _opportunity = new Opportunity();
        }

        public Opportunity Build()
        {
            return _opportunity;
        }
    }
}

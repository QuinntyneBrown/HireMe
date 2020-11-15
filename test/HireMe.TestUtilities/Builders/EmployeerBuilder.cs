using HireMe.Core.Models;

namespace HireMe.TestUtilities.Builders
{
    public class EmployeerBuilder
    {
        private Employeer _employeer;

        public EmployeerBuilder()
        {
            _employeer = new Employeer();
        }

        public Employeer Build()
        {
            return _employeer;
        }
    }
}

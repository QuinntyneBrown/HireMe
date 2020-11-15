using HireMe.Core.Models;

namespace HireMe.TestUtilities.Builders
{
    public class RoleBuilder
    {
        private Role _role;

        public RoleBuilder()
        {
            _role = new Role();
        }

        public Role Build()
        {
            return _role;
        }
    }
}

using HireMe.Core.Models;

namespace HireMe.TestUtilities.Builders
{
    public class UserBuilder
    {
        private User _user;

        public UserBuilder()
        {
            _user = new User();
        }

        public User Build()
        {
            return _user;
        }
    }
}

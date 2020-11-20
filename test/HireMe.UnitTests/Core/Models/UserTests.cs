using HireMe.Core.Models;
using System.Threading.Tasks;
using Xunit;

namespace HireMe.UnitTests.Core.Models
{
    public class UserTests
    {
        
        public UserTests()
        {

        }

        [Fact]
        public async Task ShouldCreate()
        {
            var user = new User();

            Assert.NotEqual(default, user);
        }
    }
}

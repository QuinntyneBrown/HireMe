using HireMe.TestUtilities.AuthenticationHandlers;
using HireMe.TestUtilities.Builders;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace HireMe.FunctionalTests.Controllers
{
    public class RolesController : IClassFixture<ApiTestFixture>
    {
        private readonly ApiTestFixture _factory;
        public RolesController(ApiTestFixture factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsRoles()
        {
            var token = TokenBuilder.CreateToken("Test User", new string[0]);

            var client = _factory.CreateClient(token);

            var response = await client.GetAsync("api/roles");

            response.EnsureSuccessStatusCode();
        }
    }


}

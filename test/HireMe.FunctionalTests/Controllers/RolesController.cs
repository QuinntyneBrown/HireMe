using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace HireMe.FunctionalTests.Controllers
{
    public class RolesController : IClassFixture<ApiTestFixture>
    {
        private readonly HttpClient _client;
        public RolesController(ApiTestFixture factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsRoles()
        {
            var response = await _client.GetAsync("/api/roles");
            response.EnsureSuccessStatusCode();
        }
    }
}

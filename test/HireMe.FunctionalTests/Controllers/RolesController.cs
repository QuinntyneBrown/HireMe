using HireMe.Domain.Features.Roles;
using Newtonsoft.Json;
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
            var client = _factory.CreateAuthenticatedClient();

            var httpResponseMessage = await client.GetAsync("api/roles");

            httpResponseMessage.EnsureSuccessStatusCode();

            var response = JsonConvert.DeserializeObject<GetRoles.Response>(await httpResponseMessage.Content.ReadAsStringAsync());

            Assert.NotEmpty(response.Roles);
        }
    }


}

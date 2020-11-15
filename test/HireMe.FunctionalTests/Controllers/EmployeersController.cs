using HireMe.Domain.Features.Employeers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xunit;

namespace HireMe.FunctionalTests.Controllers
{
    public class EmployeersController : IClassFixture<ApiTestFixture>
    {
        private readonly ApiTestFixture _factory;
        public EmployeersController(ApiTestFixture factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsEmployeers()
        {            
            var client = _factory.CreateAuthenticatedClient();

            var httpResponseMessage = await client.GetAsync("api/employeers");

            httpResponseMessage.EnsureSuccessStatusCode();

            var response = JsonConvert.DeserializeObject<GetEmployeers.Response>(await httpResponseMessage.Content.ReadAsStringAsync());

            Assert.Empty(response.Employeers);
        }
    }


}

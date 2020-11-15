using HireMe.Domain.Features.Opportunities;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xunit;

namespace HireMe.FunctionalTests.Controllers
{
    public class OpportunitiesController : IClassFixture<ApiTestFixture>
    {
        private readonly ApiTestFixture _factory;
        public OpportunitiesController(ApiTestFixture factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsOpportunities()
        {            
            var client = _factory.CreateAuthenticatedClient();

            var httpResponseMessage = await client.GetAsync("api/opportunities");

            httpResponseMessage.EnsureSuccessStatusCode();

            var response = JsonConvert.DeserializeObject<GetOpportunities.Response>(await httpResponseMessage.Content.ReadAsStringAsync());

            Assert.NotEmpty(response.Opportunities);
        }
    }


}

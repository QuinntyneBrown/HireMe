using HireMe.Domain.Features.DigitalAssets;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xunit;

namespace HireMe.FunctionalTests.Controllers
{
    public class DigitalAssetsController : IClassFixture<ApiTestFixture>
    {
        private readonly ApiTestFixture _factory;
        public DigitalAssetsController(ApiTestFixture factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsDigitalAssets()
        {            
            var client = _factory.CreateAuthenticatedClient();

            var httpResponseMessage = await client.GetAsync("api/digital-assets");

            httpResponseMessage.EnsureSuccessStatusCode();

            var response = JsonConvert.DeserializeObject<GetDigitalAssets.Response>(await httpResponseMessage.Content.ReadAsStringAsync());

            Assert.NotEmpty(response.DigitalAssets);
        }
    }


}

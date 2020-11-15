using HireMe.Domain.Features.Videos;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xunit;

namespace HireMe.FunctionalTests.Controllers
{
    public class VideosController : IClassFixture<ApiTestFixture>
    {
        private readonly ApiTestFixture _factory;
        public VideosController(ApiTestFixture factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsVideos()
        {            
            var client = _factory.CreateAuthenticatedClient();

            var httpResponseMessage = await client.GetAsync("api/videos");

            httpResponseMessage.EnsureSuccessStatusCode();

            var response = JsonConvert.DeserializeObject<GetVideos.Response>(await httpResponseMessage.Content.ReadAsStringAsync());

            Assert.NotEmpty(response.Videos);
        }
    }


}

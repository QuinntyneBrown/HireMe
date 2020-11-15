using HireMe.Domain.Features.Identity;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HireMe.FunctionalTests.Controllers
{
    public class UsersController : IClassFixture<ApiTestFixture>
    {
        private readonly ApiTestFixture _factory;
        public UsersController(ApiTestFixture factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsToken()
        {            
            var client = _factory.CreateClient();

            var stringContent = new StringContent(JsonConvert.SerializeObject(new { Username = "quinntynebrown@gmail.com", Password = "HireMe" }), Encoding.UTF8, "application/json");

            var httpResponseMessage = await client.PostAsync("api/users/token", stringContent);

            httpResponseMessage.EnsureSuccessStatusCode();

            var response = JsonConvert.DeserializeObject<Authenticate.Response>(await httpResponseMessage.Content.ReadAsStringAsync());

            Assert.NotEmpty(response.AccessToken);
        }
    }

}

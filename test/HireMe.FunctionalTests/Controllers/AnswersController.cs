using HireMe.Domain.Features.Answers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xunit;

namespace HireMe.FunctionalTests.Controllers
{
    public class AnswersController : IClassFixture<ApiTestFixture>
    {
        private readonly ApiTestFixture _factory;
        public AnswersController(ApiTestFixture factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsAnswers()
        {            
            var client = _factory.CreateAuthenticatedClient();

            var httpResponseMessage = await client.GetAsync("api/answers");

            httpResponseMessage.EnsureSuccessStatusCode();

            var response = JsonConvert.DeserializeObject<GetAnswers.Response>(await httpResponseMessage.Content.ReadAsStringAsync());

            Assert.NotEmpty(response.Answers);
        }
    }
}

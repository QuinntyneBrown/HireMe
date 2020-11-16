using HireMe.Core.Data;
using HireMe.Domain.Features;
using HireMe.Domain.Features.Opportunities;
using HireMe.TestUtilities.Builders;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HireMe.FunctionalTests.Controllers
{
    [Collection("Sequential")]
    public class OpportunitiesController : IClassFixture<ApiTestFixture>
    {
        private readonly ApiTestFixture _factory;
        private OpportunityBuilder OpportunityBuilder { get; } = new OpportunityBuilder();
        private EmployeerBuilder EmployeerBuilder { get; } = new EmployeerBuilder();
        public OpportunitiesController(ApiTestFixture factory)
        {
            _factory = factory;
        }


        [Fact]
        public async Task ShouldCreate()
        {            
            var client = _factory.CreateAuthenticatedClient();

            var context = _factory.Services.GetService(typeof(HireMeDbContext)) as HireMeDbContext;

            var employeer = EmployeerBuilder.Build();

            context.Employeers.Add(employeer);

            context.SaveChanges();

            var opportunity = OpportunityBuilder.Build();

            opportunity.EmployeerId = employeer.EmployeerId;

            opportunity.Name = "job";

            var stringContent = new StringContent(JsonConvert.SerializeObject(new { Opportunity = opportunity.ToDto() }), Encoding.UTF8, "application/json");

            var httpResponseMessage = await client.PostAsync("api/opportunities", stringContent);

            httpResponseMessage.EnsureSuccessStatusCode();

            var response = JsonConvert.DeserializeObject<UpsertOpportunity.Response>(await httpResponseMessage.Content.ReadAsStringAsync());

            Assert.NotNull(response.Opportunity);
            
        }


        [Fact]
        public async Task ReturnsOpportunities()
        {
            var client = _factory.CreateAuthenticatedClient();

            var httpResponseMessage = await client.GetAsync("api/opportunities");

            var context = _factory.Services.GetService(typeof(HireMeDbContext)) as HireMeDbContext;

            httpResponseMessage.EnsureSuccessStatusCode();

            var response = JsonConvert.DeserializeObject<GetOpportunities.Response>(await httpResponseMessage.Content.ReadAsStringAsync());

            Assert.Empty(response.Opportunities);
        }
    }


}

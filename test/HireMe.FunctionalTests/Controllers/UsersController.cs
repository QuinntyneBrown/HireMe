using HireMe.Domain.Features.Identity;
using Newtonsoft.Json;
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


    }


}

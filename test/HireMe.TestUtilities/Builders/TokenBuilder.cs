using BuildingBlocks.Core.Identity;
using HireMe.TestUtilities.Factories;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace HireMe.TestUtilities.Builders
{
    public class TokenBuilder
    {
        private static readonly ITokenProvider _tokenProvider;
        static TokenBuilder()
        {
            _tokenProvider = new TokenProvider(ConfigurationFactory.Create());
        }

        public static string GetAdminUserToken()
        {
            string userName = "test@test.com";
            string[] roles = { "Admin" };

            return CreateToken(userName, roles);
        }

        public static string CreateToken(string userName, IEnumerable<string> roles)
        {
            var claims = roles.Select(x => new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", x))
                .ToList();

            return _tokenProvider.Get(userName, claims);
        }
    }
}

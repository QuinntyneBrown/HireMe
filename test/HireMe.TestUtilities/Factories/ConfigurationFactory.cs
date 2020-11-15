using BuildingBlocks.Core.Helpers;
using BuildingBlocks.Core.Identity;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace HireMe.TestUtilities.Factories
{
    public static class ConfigurationFactory
    {
        private static IConfiguration configuration;
        public static IConfiguration Create()
        {
            if (configuration == null)
            {
                var secret = SecretGenerator.Generate();

                configuration = new ConfigurationBuilder()
                    .AddInMemoryCollection(new Dictionary<string, string>() {
                    { "Seed:DefaultUser:Username" ,"" },
                    { "Seed:DefaultUser:Password" ,"" },
                    { $"{nameof(Authentication)}:{nameof(Authentication.TokenPath)}" ,"/api/users/token" },
                    { $"{nameof(Authentication)}:{nameof(Authentication.ExpirationMinutes)}" ,"10080" },
                    { $"{nameof(Authentication)}:{nameof(Authentication.JwtKey)}", secret },
                    { $"{nameof(Authentication)}:{nameof(Authentication.JwtIssuer)}" ,"localhost" },
                    { $"{nameof(Authentication)}:{nameof(Authentication.JwtAudience)}" ,"all" },
                    { $"{nameof(Authentication)}:{nameof(Authentication.AuthType)}" ,"HireMe" }
                    })
                    .Build();
            }

            return configuration;
        }
    }
}

using HireMe.Api;
using HireMe.TestUtilities.AuthenticationHandlers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;


namespace HireMe.FunctionalTests
{
    public class ApiTestFixture : WebApplicationFactory<Startup>
    {
        private static string GenerateSecret()
        {
            var tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
            tripleDESCryptoServiceProvider.GenerateKey();
            return Convert.ToBase64String(tripleDESCryptoServiceProvider.Key);
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing");
        }

        public HttpClient CreateClient(string token, string scheme = "Test")
        {
            var client = WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddAuthentication(scheme)
                        .AddScheme<AuthenticationSchemeOptions, TestAuthenticationHandler>(
                            scheme, options => { });
                });
            }).CreateClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme, token);

            return client;
        }
    }
}

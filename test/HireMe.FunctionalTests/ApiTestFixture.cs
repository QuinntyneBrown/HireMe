using HireMe.Api;
using HireMe.Core.Data;
using HireMe.Core.Seeding;
using HireMe.TestUtilities.AuthenticationHandlers;
using HireMe.TestUtilities.Builders;
using HireMe.TestUtilities.Factories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using System.Net.Http.Headers;


namespace HireMe.FunctionalTests
{
    public class ApiTestFixture : WebApplicationFactory<Startup>
    {
        public HireMeDbContext Context { get; private set; }
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing");

            builder.ConfigureServices(services =>
            {
                services.AddEntityFrameworkInMemoryDatabase();

                var provider = services
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                services.AddDbContext<HireMeDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                    options.UseInternalServiceProvider(provider);
                });

                var serviceProvider = services.BuildServiceProvider();

                using (var scope = serviceProvider.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    
                    Context = scopedServices.GetRequiredService<HireMeDbContext>();

                    Context.Database.EnsureCreated();

                    SeedData.Seed(Context, ConfigurationFactory.Create());
                }
            });
        }

        public HttpClient CreateAuthenticatedClient(string token = null, string scheme = "Test")
        {
            if(string.IsNullOrEmpty(token))
                token = TokenFactory.CreateToken("Test User", Array.Empty<string>());

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

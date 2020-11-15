using HireMe.Core.Data;
using HireMe.Core.Seeding;
using Microsoft.EntityFrameworkCore;
using System;

namespace HireMe.TestUtilities.Factories
{
    public static class DbContextFactory
    {
        public static HireMeDbContext Create()
        {
            var configuration = ConfigurationFactory.Create();

            var options = new DbContextOptionsBuilder<HireMeDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new HireMeDbContext(options);

            SeedData.Seed(context, configuration);

            return context;
        }
    }
}

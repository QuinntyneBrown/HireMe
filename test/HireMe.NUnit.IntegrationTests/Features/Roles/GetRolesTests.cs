using HireMe.Domain.Features.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using HireMe.Core.Models;
using NUnit.Framework;

namespace HireMe.NUnit.IntegrationTests.Features.Roles
{
    using static Testing;
    public class GetRolesTests: TestBase
    {
        [Test]
        public async Task ShouldReturnRoles()
        {
            await AddAsync(new Role()
            {

            });

            var query = new GetRoles.Request();

            var result = await SendAsync(query);


            result.Should().NotBeNull();
        }
    }
}

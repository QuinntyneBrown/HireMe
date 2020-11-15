using Microsoft.Extensions.Configuration;
using HireMe.Core.Data;
using System.Linq;
using HireMe.Core.Models;
using BuildingBlocks.Core.Identity;

namespace HireMe.Core.Seeding
{
    public static class SeedData
    {
        public static void Seed(HireMeDbContext context, IConfiguration configuration)
        {
            RoleConfiguration.Seed(context);
            UserConfiguration.Seed(context, configuration);
        }
    }

    internal class UserConfiguration
    {
        public static void Seed(HireMeDbContext context, IConfiguration configuration)
        {
            var user = context.Users.SingleOrDefault(x => x.Username == configuration["Seed:DefaultUser:Username"]);

            if (user == null)
            {
                user = new User
                {
                    Username = configuration["Seed:DefaultUser:Username"]
                };

                user.Password = new PasswordHasher().HashPassword(user.Salt, configuration["Seed:DefaultUser:Password"]);

                user.Roles.Add(context.Roles.Single(x => x.Name == "Admin"));

                context.Users.Add(user);

                context.SaveChanges();

            }
        }
    }

    internal class RoleConfiguration
    {
        public static void Seed(HireMeDbContext context)
        {
            var role = context.Roles.SingleOrDefault(x => x.Name == "Admin");

            if (role == null)
            {
                role = new Role
                {
                    Name = "Admin"
                };

                context.Roles.Add(role);
            }

            var role1 = context.Roles.SingleOrDefault(x => x.Name == "Employeer");

            if (role1 == null)
            {
                role1 = new Role
                {
                    Name = "Employeer"
                };

                context.Roles.Add(role1);
            }

            var role2 = context.Roles.SingleOrDefault(x => x.Name == "Candidate");

            if (role2 == null)
            {
                role2 = new Role
                {
                    Name = "Candidate"
                };

                context.Roles.Add(role2);
            }

            context.SaveChanges();
        }
    }
}

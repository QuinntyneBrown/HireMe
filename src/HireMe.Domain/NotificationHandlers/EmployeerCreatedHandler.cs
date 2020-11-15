using BuildingBlocks.Core.Identity;
using HireMe.Core.Data;
using HireMe.Core.DomainEvents;
using HireMe.Core.Models;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HireMe.Domain.NotificationHandlers.EmployeerCreatedHandler
{
    public class EmployeerCreatedHandler : INotificationHandler<EmployeerCreatedEvent>
    {
        private readonly IHireMeDbContext _context;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IConfiguration _configuration;

        public EmployeerCreatedHandler(IHireMeDbContext context, IPasswordHasher passwordHasher, IConfiguration configuration)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
        }

        public async Task Handle(EmployeerCreatedEvent notification, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Username = notification.Employeer.Email
            };

            user.Password = _passwordHasher.HashPassword(user.Salt, _configuration["Seed:DefaultUser:Password"]);

            user.Roles.Add(_context.Roles.Single(x => x.Name == "Employeer"));

            _context.Users.Add(user);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

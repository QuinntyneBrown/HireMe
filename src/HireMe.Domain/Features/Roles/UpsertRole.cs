using FluentValidation;
using MediatR;
using HireMe.Core.Data;
using HireMe.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace HireMe.Domain.Features.Roles
{
    public class UpsertRole
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Role).NotNull();
                RuleFor(request => request.Role).SetValidator(new RoleValidator());
            }
        }

        public class Request : IRequest<Response> {  
            public RoleDto Role { get; set; }
        }

        public class Response
        {
            public RoleDto Role { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHireMeDbContext _context;

            public Handler(IHireMeDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {

                var role = await _context.Roles.FindAsync(request.Role.RoleId);

                if (role == null)
                {
                    role = new Role();
                    await _context.Roles.AddAsync(role);
                }

                role.RoleId = request.Role.RoleId;

                await _context.SaveChangesAsync(cancellationToken);

			    return new Response() { 
                    Role = role.ToDto()
                };
            }
        }
    }
}

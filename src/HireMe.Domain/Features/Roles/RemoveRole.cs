using MediatR;
using HireMe.Core.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HireMe.Domain.Features.Roles
{
    public class RemoveRole
    {
        public class Request : IRequest<Unit>
        {
            public Guid RoleId { get; set; }
        }

        public class Handler : IRequestHandler<Request, Unit>
        {
            private readonly IHireMeDbContext _context;

            public Handler(IHireMeDbContext context) => _context = context;

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {

                _context.Roles.Remove(await _context.Roles.FindAsync(request.RoleId));

                await _context.SaveChangesAsync(cancellationToken);

                return new Unit();
            }
        }
    }
}

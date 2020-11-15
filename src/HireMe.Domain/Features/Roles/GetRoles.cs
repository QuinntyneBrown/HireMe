using MediatR;
using Microsoft.EntityFrameworkCore;
using HireMe.Core.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HireMe.Domain.Features.Roles
{
    public class GetRoles
    {
        public class Request : IRequest<Response> { }

        public class Response
        {
            public List<RoleDto> Roles { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHireMeDbContext _context;

            public Handler(IHireMeDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new Response()
                {
                    Roles = await _context.Roles.Select(x => x.ToDto()).ToListAsync()
                };
            }
        }
    }
}

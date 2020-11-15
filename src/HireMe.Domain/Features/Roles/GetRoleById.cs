using MediatR;
using HireMe.Core.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HireMe.Domain.Features.Roles
{
    public class GetRoleById
    {
        public class Request : IRequest<Response> {  
            public Guid RoleId { get; set; }        
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
			    return new Response() { 
                    Role = (await _context.Roles.FindAsync(request.RoleId)).ToDto()
                };
            }
        }
    }
}

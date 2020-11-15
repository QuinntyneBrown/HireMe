using MediatR;
using HireMe.Core.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HireMe.Domain.Features.Employeers
{
    public class GetEmployeerById
    {
        public class Request : IRequest<Response> {  
            public Guid EmployeerId { get; set; }        
        }

        public class Response
        {
            public EmployeerDto Employeer { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHireMeDbContext _context;

            public Handler(IHireMeDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {
			    return new Response() { 
                    Employeer = (await _context.Employeers.FindAsync(request.EmployeerId)).ToDto()
                };
            }
        }
    }
}

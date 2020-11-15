using MediatR;
using Microsoft.EntityFrameworkCore;
using HireMe.Core.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HireMe.Domain.Features.Candidates
{
    public class GetCandidates
    {
        public class Request : IRequest<Response> {  }

        public class Response
        {
            public List<CandidateDto> Candidates { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHireMeDbContext _context;

            public Handler(IHireMeDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {
			    return new Response() { 
                    Candidates = await _context.Candidates.Select(x => x.ToDto()).ToListAsync()
                };
            }
        }
    }
}

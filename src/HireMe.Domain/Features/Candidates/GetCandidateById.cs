using MediatR;
using HireMe.Core.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HireMe.Domain.Features.Candidates
{
    public class GetCandidateById
    {
        public class Request : IRequest<Response>
        {
            public Guid CandidateId { get; set; }
        }

        public class Response
        {
            public CandidateDto Candidate { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHireMeDbContext _context;

            public Handler(IHireMeDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new Response()
                {
                    Candidate = (await _context.Candidates.FindAsync(request.CandidateId)).ToDto()
                };
            }
        }
    }
}

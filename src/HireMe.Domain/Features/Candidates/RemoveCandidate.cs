using MediatR;
using HireMe.Core.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HireMe.Domain.Features.Candidates
{
    public class RemoveCandidate
    {
        public class Request : IRequest<Unit>
        {
            public Guid CandidateId { get; set; }
        }

        public class Handler : IRequestHandler<Request, Unit>
        {
            private readonly IHireMeDbContext _context;

            public Handler(IHireMeDbContext context) => _context = context;

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {

                _context.Candidates.Remove(await _context.Candidates.FindAsync(request.CandidateId));

                await _context.SaveChangesAsync(cancellationToken);

                return new Unit();
            }
        }
    }
}

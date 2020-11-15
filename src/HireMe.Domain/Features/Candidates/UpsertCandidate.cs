using FluentValidation;
using MediatR;
using HireMe.Core.Data;
using HireMe.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace HireMe.Domain.Features.Candidates
{
    public class UpsertCandidate
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Candidate).NotNull();
                RuleFor(request => request.Candidate).SetValidator(new CandidateValidator());
            }
        }

        public class Request : IRequest<Response>
        {
            public CandidateDto Candidate { get; set; }
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

                var candidate = await _context.Candidates.FindAsync(request.Candidate.CandidateId);

                if (candidate == null)
                {
                    candidate = new Candidate();
                    await _context.Candidates.AddAsync(candidate);
                }

                candidate.CandidateId = request.Candidate.CandidateId;

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Candidate = candidate.ToDto()
                };
            }
        }
    }
}

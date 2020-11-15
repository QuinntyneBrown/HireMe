using MediatR;
using HireMe.Core.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HireMe.Domain.Features.Opportunities
{
    public class GetOpportunityById
    {
        public class Request : IRequest<Response>
        {
            public Guid OpportunityId { get; set; }
        }

        public class Response
        {
            public OpportunityDto Opportunity { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHireMeDbContext _context;

            public Handler(IHireMeDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new Response()
                {
                    Opportunity = (await _context.Opportunities.FindAsync(request.OpportunityId)).ToDto()
                };
            }
        }
    }
}

using HireMe.Core.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HireMe.Domain.Features.Opportunities
{
    public class GetOpportunitiesByEmployeerId
    {
        public class Request : IRequest<Response>
        {
            public Guid EmployeerId { get; set; }
        }

        public class Response
        {
            public ICollection<OpportunityDto> Opportunities { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHireMeDbContext _context;

            public Handler(IHireMeDbContext context)
            {
                _context = context;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {

                var opporitunities = await _context.Opportunities.Where(x => x.EmployeerId == request.EmployeerId).ToListAsync(cancellationToken);

                return new Response
                {
                    Opportunities = opporitunities.Select(x => x.ToDto()).ToList()
                };
            }
        }
    }
}

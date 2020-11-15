using MediatR;
using HireMe.Core.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HireMe.Domain.Features.Opportunities
{
    public class RemoveOpportunity
    {
        public class Request : IRequest<Unit> {  
            public Guid OpportunityId { get; set; }        
        }

        public class Handler : IRequestHandler<Request, Unit>
        {
            private readonly IHireMeDbContext _context;

            public Handler(IHireMeDbContext context) => _context = context;

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken) {
                
                _context.Opportunities.Remove(await _context.Opportunities.FindAsync(request.OpportunityId));
                
                await _context.SaveChangesAsync(cancellationToken);			    
                
                return new Unit();
            }
        }
    }
}

using FluentValidation;
using MediatR;
using HireMe.Core.Data;
using HireMe.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace HireMe.Domain.Features.Opportunities
{
    public class UpsertOpportunity
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Opportunity).NotNull();
                RuleFor(request => request.Opportunity).SetValidator(new OpportunityValidator());
            }
        }

        public class Request : IRequest<Response> {  
            public OpportunityDto Opportunity { get; set; }
        }

        public class Response
        {
            public OpportunityDto Opportunity { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHireMeDbContext _context;

            public Handler(IHireMeDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {

                var opportunity = await _context.Opportunities.FindAsync(request.Opportunity.OpportunityId);

                if (opportunity == null)
                {
                    opportunity = new Opportunity();
                    await _context.Opportunities.AddAsync(opportunity);
                }

                opportunity.OpportunityId = request.Opportunity.OpportunityId;
                opportunity.Name = request.Opportunity.Name;
                opportunity.EmployeerId = request.Opportunity.EmployeerId;
                

                await _context.SaveChangesAsync(cancellationToken);

			    return new Response() { 
                    Opportunity = opportunity.ToDto()
                };
            }
        }
    }
}

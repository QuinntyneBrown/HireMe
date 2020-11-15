using FluentValidation;
using MediatR;
using HireMe.Core.Data;
using HireMe.Core.Models;
using System.Threading;
using System.Threading.Tasks;
using HireMe.Core.DomainEvents;

namespace HireMe.Domain.Features.Employeers
{
    public class UpsertEmployeer
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Employeer).NotNull();
                RuleFor(request => request.Employeer).SetValidator(new EmployeerValidator());
            }
        }

        public class Request : IRequest<Response>
        {
            public EmployeerDto Employeer { get; set; }
        }

        public class Response
        {
            public EmployeerDto Employeer { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHireMeDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IHireMeDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {

                var employeer = await _context.Employeers.FindAsync(request.Employeer.EmployeerId);

                if (employeer == null)
                {
                    employeer = new Employeer();
                    await _context.Employeers.AddAsync(employeer, cancellationToken);
                }

                employeer.FirstName = request.Employeer.FirstName;

                employeer.LastName = request.Employeer.LastName;

                employeer.Email = request.Employeer.Email;

                await _context.SaveChangesAsync(cancellationToken);

                if (request.Employeer.EmployeerId == default)
                {
                    await _mediator.Publish(new EmployeerCreatedEvent(employeer), cancellationToken);
                }

                return new Response()
                {
                    Employeer = employeer.ToDto()
                };
            }
        }
    }
}

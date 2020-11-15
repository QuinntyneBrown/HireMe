using FluentValidation;
using MediatR;
using HireMe.Core.Data;
using HireMe.Core.Models;
using System.Threading;
using System.Threading.Tasks;

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

        public class Request : IRequest<Response> {  
            public EmployeerDto Employeer { get; set; }
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

                var employeer = await _context.Employeers.FindAsync(request.Employeer.EmployeerId);

                if (employeer == null)
                {
                    employeer = new Employeer();
                    await _context.Employeers.AddAsync(employeer);
                }

                employeer.EmployeerId = request.Employeer.EmployeerId;

                await _context.SaveChangesAsync(cancellationToken);

			    return new Response() { 
                    Employeer = employeer.ToDto()
                };
            }
        }
    }
}

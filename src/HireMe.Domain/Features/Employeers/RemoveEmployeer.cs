using MediatR;
using HireMe.Core.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HireMe.Domain.Features.Employeers
{
    public class RemoveEmployeer
    {
        public class Request : IRequest<Unit>
        {
            public Guid EmployeerId { get; set; }
        }

        public class Handler : IRequestHandler<Request, Unit>
        {
            private readonly IHireMeDbContext _context;

            public Handler(IHireMeDbContext context) => _context = context;

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {

                _context.Employeers.Remove(await _context.Employeers.FindAsync(request.EmployeerId));

                await _context.SaveChangesAsync(cancellationToken);

                return new Unit();
            }
        }
    }
}

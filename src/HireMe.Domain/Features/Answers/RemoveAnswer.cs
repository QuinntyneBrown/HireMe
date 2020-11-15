using MediatR;
using HireMe.Core.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HireMe.Domain.Features.Answers
{
    public class RemoveAnswer
    {
        public class Request : IRequest<Unit>
        {
            public Guid AnswerId { get; set; }
        }

        public class Handler : IRequestHandler<Request, Unit>
        {
            private readonly IHireMeDbContext _context;

            public Handler(IHireMeDbContext context) => _context = context;

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {

                _context.Answers.Remove(await _context.Answers.FindAsync(request.AnswerId));

                await _context.SaveChangesAsync(cancellationToken);

                return new Unit();
            }
        }
    }
}

using MediatR;
using HireMe.Core.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HireMe.Domain.Features.Questions
{
    public class RemoveQuestion
    {
        public class Request : IRequest<Unit> {  
            public Guid QuestionId { get; set; }        
        }

        public class Handler : IRequestHandler<Request, Unit>
        {
            private readonly IHireMeDbContext _context;

            public Handler(IHireMeDbContext context) => _context = context;

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken) {
                
                _context.Questions.Remove(await _context.Questions.FindAsync(request.QuestionId));
                
                await _context.SaveChangesAsync(cancellationToken);			    
                
                return new Unit();
            }
        }
    }
}

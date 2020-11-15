using MediatR;
using HireMe.Core.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HireMe.Domain.Features.Answers
{
    public class GetAnswerById
    {
        public class Request : IRequest<Response> {  
            public Guid AnswerId { get; set; }        
        }

        public class Response
        {
            public AnswerDto Answer { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHireMeDbContext _context;

            public Handler(IHireMeDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {
			    return new Response() { 
                    Answer = (await _context.Answers.FindAsync(request.AnswerId)).ToDto()
                };
            }
        }
    }
}

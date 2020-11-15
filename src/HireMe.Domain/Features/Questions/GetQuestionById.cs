using MediatR;
using HireMe.Core.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HireMe.Domain.Features.Questions
{
    public class GetQuestionById
    {
        public class Request : IRequest<Response> {  
            public Guid QuestionId { get; set; }        
        }

        public class Response
        {
            public QuestionDto Question { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHireMeDbContext _context;

            public Handler(IHireMeDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {
			    return new Response() { 
                    Question = (await _context.Questions.FindAsync(request.QuestionId)).ToDto()
                };
            }
        }
    }
}

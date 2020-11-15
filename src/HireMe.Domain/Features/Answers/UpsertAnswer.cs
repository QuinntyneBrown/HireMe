using FluentValidation;
using MediatR;
using HireMe.Core.Data;
using HireMe.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace HireMe.Domain.Features.Answers
{
    public class UpsertAnswer
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Answer).NotNull();
                RuleFor(request => request.Answer).SetValidator(new AnswerValidator());
            }
        }

        public class Request : IRequest<Response> {  
            public AnswerDto Answer { get; set; }
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

                var answer = await _context.Answers.FindAsync(request.Answer.AnswerId);

                if (answer == null)
                {
                    answer = new Answer();
                    await _context.Answers.AddAsync(answer);
                }

                answer.AnswerId = request.Answer.AnswerId;

                await _context.SaveChangesAsync(cancellationToken);

			    return new Response() { 
                    Answer = answer.ToDto()
                };
            }
        }
    }
}

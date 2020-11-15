using FluentValidation;
using MediatR;
using HireMe.Core.Data;
using HireMe.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace HireMe.Domain.Features.Questions
{
    public class UpsertQuestion
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Question).NotNull();
                RuleFor(request => request.Question).SetValidator(new QuestionValidator());
            }
        }

        public class Request : IRequest<Response>
        {
            public QuestionDto Question { get; set; }
        }

        public class Response
        {
            public QuestionDto Question { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHireMeDbContext _context;

            public Handler(IHireMeDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {

                var question = await _context.Questions.FindAsync(request.Question.QuestionId);

                if (question == null)
                {
                    question = new Question();
                    await _context.Questions.AddAsync(question);
                }

                question.QuestionId = request.Question.QuestionId;

                question.OpportunityId = request.Question.OpportunityId;

                question.Body = request.Question.Body;

                question.SortOrder = request.Question.SortOrder;

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Question = question.ToDto()
                };
            }
        }
    }
}

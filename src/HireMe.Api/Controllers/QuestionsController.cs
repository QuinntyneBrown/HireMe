using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HireMe.Domain.Features.Questions;
using System.Net;
using System.Threading.Tasks;

namespace HireMe.Api.Controllers
{
    [ApiController]
    [Route("api/questions")]
    public class QuestionsController
    {
        private readonly IMediator _mediator;

        public QuestionsController(IMediator mediator) => _mediator = mediator;

        [Authorize]
        [HttpPost(Name = "UpsertQuestionRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpsertQuestion.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpsertQuestion.Response>> Upsert([FromBody] UpsertQuestion.Request request)
            => await _mediator.Send(request);

        [Authorize]
        [HttpDelete("{questionId}", Name = "RemoveQuestionRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task Remove([FromRoute] RemoveQuestion.Request request)
            => await _mediator.Send(request);

        [Authorize]
        [HttpGet("{questionId}", Name = "GetQuestionByIdRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetQuestionById.Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<GetQuestionById.Response>> GetById([FromRoute] GetQuestionById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.Question == null)
            {
                return new NotFoundObjectResult(request.QuestionId);
            }

            return response;
        }

        [Authorize]
        [HttpGet(Name = "GetquestionsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetQuestions.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetQuestions.Response>> Get()
            => await _mediator.Send(new GetQuestions.Request());
    }
}

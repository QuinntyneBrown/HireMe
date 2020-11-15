using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HireMe.Domain.Features.Answers;
using System.Net;
using System.Threading.Tasks;

namespace HireMe.Api.Controllers
{
    [ApiController]
    [Route("api/answers")]
    public class AnswersController
    {
        private readonly IMediator _mediator;

        public AnswersController(IMediator mediator) => _mediator = mediator;

        [Authorize]
        [HttpPost(Name = "UpsertAnswerRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpsertAnswer.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpsertAnswer.Response>> Upsert([FromBody] UpsertAnswer.Request request)
            => await _mediator.Send(request);

        [Authorize]
        [HttpDelete("{answerId}", Name = "RemoveAnswerRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task Remove([FromRoute] RemoveAnswer.Request request)
            => await _mediator.Send(request);

        [Authorize]
        [HttpGet("{answerId}", Name = "GetAnswerByIdRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetAnswerById.Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<GetAnswerById.Response>> GetById([FromRoute] GetAnswerById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.Answer == null)
            {
                return new NotFoundObjectResult(request.AnswerId);
            }

            return response;
        }

        [Authorize]
        [HttpGet(Name = "GetanswersRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetAnswers.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetAnswers.Response>> Get()
            => await _mediator.Send(new GetAnswers.Request());
    }
}

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HireMe.Domain.Features.Candidates;
using System.Net;
using System.Threading.Tasks;

namespace HireMe.Api.Controllers
{
    [ApiController]
    [Route("api/candidates")]
    public class CandidatesController
    {
        private readonly IMediator _mediator;

        public CandidatesController(IMediator mediator) => _mediator = mediator;

        [Authorize]
        [HttpPost(Name = "UpsertCandidateRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpsertCandidate.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpsertCandidate.Response>> Upsert([FromBody]UpsertCandidate.Request request)
            => await _mediator.Send(request);

        [Authorize]
        [HttpDelete("{candidateId}", Name = "RemoveCandidateRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task Remove([FromRoute]RemoveCandidate.Request request)
            => await _mediator.Send(request);

        [Authorize]
        [HttpGet("{candidateId}", Name = "GetCandidateByIdRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCandidateById.Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<GetCandidateById.Response>> GetById([FromRoute]GetCandidateById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.Candidate == null)
            {
                return new NotFoundObjectResult(request.CandidateId);
            }

            return response;
        }

        [Authorize]
        [HttpGet(Name = "GetcandidatesRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCandidates.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCandidates.Response>> Get()
            => await _mediator.Send(new GetCandidates.Request());           
    }
}

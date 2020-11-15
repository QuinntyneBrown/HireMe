using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HireMe.Domain.Features.Employeers;
using System.Net;
using System.Threading.Tasks;

namespace HireMe.Api.Controllers
{
    [ApiController]
    [Route("api/employeers")]
    public class EmployeersController
    {
        private readonly IMediator _mediator;

        public EmployeersController(IMediator mediator) => _mediator = mediator;

        [Authorize]
        [HttpPost(Name = "UpsertEmployeerRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpsertEmployeer.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpsertEmployeer.Response>> Upsert([FromBody]UpsertEmployeer.Request request)
            => await _mediator.Send(request);

        [Authorize]
        [HttpDelete("{employeerId}", Name = "RemoveEmployeerRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task Remove([FromRoute]RemoveEmployeer.Request request)
            => await _mediator.Send(request);

        [Authorize]
        [HttpGet("{employeerId}", Name = "GetEmployeerByIdRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetEmployeerById.Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<GetEmployeerById.Response>> GetById([FromRoute]GetEmployeerById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.Employeer == null)
            {
                return new NotFoundObjectResult(request.EmployeerId);
            }

            return response;
        }

        [Authorize]
        [HttpGet(Name = "GetemployeersRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetEmployeers.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetEmployeers.Response>> Get()
            => await _mediator.Send(new GetEmployeers.Request());           
    }
}

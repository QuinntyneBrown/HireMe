using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HireMe.Domain.Features.Roles;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HireMe.Api.Controllers
{
    [ApiController]
    [Route("api/roles")]
    public class RolesController
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RolesController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor; 
        }

        [Authorize]
        [HttpPost(Name = "UpsertRoleRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpsertRole.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpsertRole.Response>> Upsert([FromBody] UpsertRole.Request request)
            => await _mediator.Send(request);

        [Authorize]
        [HttpDelete("{roleId}", Name = "RemoveRoleRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task Remove([FromRoute] RemoveRole.Request request)
            => await _mediator.Send(request);

        [Authorize]
        [HttpGet("{roleId}", Name = "GetRoleByIdRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetRoleById.Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<GetRoleById.Response>> GetById([FromRoute] GetRoleById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.Role == null)
            {
                return new NotFoundObjectResult(request.RoleId);
            }

            return response;
        }

        [Authorize]
        [HttpGet(Name = "GetRolesRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetRoles.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetRoles.Response>> Get()
            => await _mediator.Send(new GetRoles.Request());
    }
}

using HireMe.Domain.Features.Identity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace HireMe.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController
    {
        private readonly IMediator _mediator;
        
        public UsersController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost("token", Name = "UserSignInRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Authenticate.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Authenticate.Response>> SignIn(Authenticate.Request request)
            => await _mediator.Send(request);

        [Authorize]
        [HttpGet("current", Name = "GetCurrentUserRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCurrentUser.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCurrentUser.Response>> Get([FromRoute] GetCurrentUser.Request request)
            => await _mediator.Send(request);

    }
}

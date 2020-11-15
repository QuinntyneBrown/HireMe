using HireMe.Domain.Features.DigitalAssets;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace HireMe.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/digitalAssets")]
    public class DigitalAssetsController
    {
        private readonly IMediator _mediator;

        public DigitalAssetsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("range")]
        public async Task<ActionResult<GetDigitalAssetsByIds.Response>> GetByIds([FromQuery] GetDigitalAssetsByIds.Request request)
            => await _mediator.Send(request);

        [Authorize]
        [HttpPost("upload"), DisableRequestSizeLimit]
        public async Task<ActionResult<UploadDigitalAsset.Response>> Save()
            => await _mediator.Send(new UploadDigitalAsset.Request());

        [AllowAnonymous]
        [HttpGet("serve/{digitalAssetId}")]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(FileContentResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Serve([FromRoute] GetDigitalAssetById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.DigitalAsset == null)
                return new NotFoundObjectResult(null);

            return new FileContentResult(response.DigitalAsset.Bytes, response.DigitalAsset.ContentType);
        }
    }
}

using FluentValidation;
using MediatR;
using HireMe.Core.Data;
using HireMe.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace HireMe.Domain.Features.DigitalAssets
{
    public class UpsertDigitalAsset
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.DigitalAsset).NotNull();
                RuleFor(request => request.DigitalAsset).SetValidator(new DigitalAssetValidator());
            }
        }

        public class Request : IRequest<Response>
        {
            public DigitalAssetDto DigitalAsset { get; set; }
        }

        public class Response
        {
            public DigitalAssetDto DigitalAsset { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHireMeDbContext _context;

            public Handler(IHireMeDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {

                var digitalAsset = await _context.DigitalAssets.FindAsync(request.DigitalAsset.DigitalAssetId);

                if (digitalAsset == null)
                {
                    digitalAsset = new DigitalAsset();
                    await _context.DigitalAssets.AddAsync(digitalAsset);
                }

                digitalAsset.DigitalAssetId = request.DigitalAsset.DigitalAssetId;
                digitalAsset.Name = request.DigitalAsset.Name;
                digitalAsset.Bytes = request.DigitalAsset.Bytes;
                digitalAsset.ContentType = request.DigitalAsset.ContentType;

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    DigitalAsset = digitalAsset.ToDto()
                };
            }
        }
    }
}

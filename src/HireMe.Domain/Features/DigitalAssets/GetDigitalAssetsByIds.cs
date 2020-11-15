using HireMe.Core.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HireMe.Domain.Features.DigitalAssets
{
    public class GetDigitalAssetsByIds
    {
        public class Request : IRequest<Response>
        {
            public Guid[] DigitalAssetIds { get; set; }
        }

        public class Response
        {
            public IEnumerable<DigitalAssetDto> DigitalAssets { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public IHireMeDbContext _context { get; set; }
            public Handler(IHireMeDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
                => new Response()
                {
                    DigitalAssets = await _context.DigitalAssets
                    .Where(x => request.DigitalAssetIds.Contains(x.DigitalAssetId))
                    .Select(x => x.ToDto())
                    .ToListAsync()
                };
        }
    }
}

using MediatR;
using HireMe.Core.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HireMe.Domain.Features.Videos
{
    public class GetVideoById
    {
        public class Request : IRequest<Response> {  
            public Guid VideoId { get; set; }        
        }

        public class Response
        {
            public VideoDto Video { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHireMeDbContext _context;

            public Handler(IHireMeDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {
			    return new Response() { 
                    Video = (await _context.Videos.FindAsync(request.VideoId)).ToDto()
                };
            }
        }
    }
}

using HireMe.Core.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HireMe.Domain.Features.Identity
{
    public class GetCurrentUser
    {
        public class Request : IRequest<Response> { }

        public class Response
        {
            public UserDto CurrentUser { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHireMeDbContext _context;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public Handler(IHireMeDbContext context, IHttpContextAccessor httpContextAccessor)
            {
                _context = context;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {

                var user = await _context.Users.Include(x => x.Roles).SingleAsync(x => x.Username == _httpContextAccessor.HttpContext.User.Identity.Name);
                return new Response()
                {
                    CurrentUser = user.ToDto()
                };
            }
        }
    }
}

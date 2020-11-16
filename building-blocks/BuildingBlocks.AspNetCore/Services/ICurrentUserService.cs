using System.Security.Claims;

namespace BuildingBlocks.AspNetCore.Services
{
    public interface ICurrentUserService
    {
        ClaimsPrincipal Get();
    }
}
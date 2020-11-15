using HireMe.Core.Models;
using HireMe.Domain.Features.Roles;

namespace HireMe.Domain.Features
{
    public static class RoleExtensions
    {
        public static RoleDto ToDto(this Role role)
        {
            return new RoleDto
            {
                RoleId = role.RoleId,
            };
        }
    }
}

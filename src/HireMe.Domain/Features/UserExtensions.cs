using HireMe.Core.Models;
using HireMe.Domain.Features.Identity;
using System.Linq;

namespace HireMe.Domain.Features
{
    public static class UserExtensions
    {
        public static UserDto ToDto(this User user)
        {
            return new UserDto
            {
                UserId = user.UserId,
                Username = user.Username,
                Roles = user.Roles.Select(x => x.ToDto()).ToList()
            };
        }
    }
}

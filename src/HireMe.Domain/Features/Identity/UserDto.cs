using HireMe.Domain.Features.Roles;
using System;
using System.Collections.Generic;

namespace HireMe.Domain.Features.Identity
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public ICollection<RoleDto> Roles { get; set; } = new HashSet<RoleDto>();
    }
}

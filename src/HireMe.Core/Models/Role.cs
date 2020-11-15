using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HireMe.Core.Models
{
    public class Role
    {
        [Key]
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public ICollection<User> Roles { get; set; } = new HashSet<User>();
    }

}

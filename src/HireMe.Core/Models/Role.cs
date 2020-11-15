using System;
using System.ComponentModel.DataAnnotations;

namespace HireMe.Core.Models
{
    public class Role
    {
        [Key]
        public Guid RoleId { get; set; }
    }

}

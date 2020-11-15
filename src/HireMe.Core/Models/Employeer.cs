using System;
using System.ComponentModel.DataAnnotations;

namespace HireMe.Core.Models
{
    public class Employeer
    {
        [Key]
        public Guid EmployeerId { get; set; }
    }

}

using System;

namespace HireMe.Domain.Features.Employeers
{
    public class EmployeerDto
    {
        public Guid EmployeerId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

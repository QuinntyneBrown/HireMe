using HireMe.Core.Models;
using HireMe.Domain.Features.Employeers;

namespace HireMe.Domain.Features
{
    public static class EmployeerExtensions
    {
        public static EmployeerDto ToDto(this Employeer employeer)
        {
            return new EmployeerDto
            {
                EmployeerId = employeer.EmployeerId,
                Email = employeer.Email,
                FirstName = employeer.FirstName,
                LastName = employeer.LastName,
            };
        }
    }
}

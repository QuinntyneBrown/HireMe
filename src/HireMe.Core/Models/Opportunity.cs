using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HireMe.Core.Models
{
    public class Opportunity
    {
        [Key]
        public Guid OpportunityId { get; set; }
        public string Name { get; set; }
        public Guid EmployeerId { get; set; }
        public ICollection<Question> Questions { get; set; } = new HashSet<Question>();
    }

}

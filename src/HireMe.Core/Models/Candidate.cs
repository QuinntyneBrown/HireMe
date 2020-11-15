using System;
using System.ComponentModel.DataAnnotations;

namespace HireMe.Core.Models
{
    public class Candidate
    {
        [Key]
        public Guid CandidateId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}

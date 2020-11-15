using System;
using System.ComponentModel.DataAnnotations;

namespace HireMe.Core.Models
{
    public class Candidate
    {
        [Key]
        public Guid CandidateId { get; set; }
    }

}

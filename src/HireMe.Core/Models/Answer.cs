using System;
using System.ComponentModel.DataAnnotations;

namespace HireMe.Core.Models
{
    public class Answer
    {
        [Key]
        public Guid AnswerId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid VideoId { get; set; }
        public Guid CandidateId { get; set; }
    }

}

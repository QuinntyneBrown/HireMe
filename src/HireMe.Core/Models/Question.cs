using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HireMe.Core.Models
{
    public class Question
    {
        [Key]
        public Guid QuestionId { get; set; }
        [ForeignKey("Opportunity")]
        public Guid OpportunityId { get; set; }
        public string Body { get; set; }
        public int? SortOrder { get; set; }
        public Opportunity Opportunity { get; set; }
    }
}

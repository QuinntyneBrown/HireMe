using System;
using System.ComponentModel.DataAnnotations;

namespace HireMe.Core.Models
{
    public class Question
    {
        [Key]
        public Guid QuestionId { get; set; }
    }

}

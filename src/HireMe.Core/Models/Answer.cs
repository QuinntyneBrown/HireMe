using System;
using System.ComponentModel.DataAnnotations;

namespace HireMe.Core.Models
{
    public class Answer
    {
        [Key]
        public Guid AnswerId { get; set; }
    }

}

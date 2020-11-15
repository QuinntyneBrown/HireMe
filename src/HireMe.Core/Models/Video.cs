using System;
using System.ComponentModel.DataAnnotations;

namespace HireMe.Core.Models
{
    public class Video
    {
        [Key]
        public Guid VideoId { get; set; }
        public string YouTubeId { get; set; }
    }

}

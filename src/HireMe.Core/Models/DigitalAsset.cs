using System;
using System.ComponentModel.DataAnnotations;

namespace HireMe.Core.Models
{
    public class DigitalAsset
    {
        [Key]
        public Guid DigitalAssetId { get; set; }
        public string Name { get; set; }
        public byte[] Bytes { get; set; }
        public string ContentType { get; set; }
    }
}

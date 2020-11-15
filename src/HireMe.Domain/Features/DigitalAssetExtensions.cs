using HireMe.Core.Models;
using HireMe.Domain.Features.DigitalAssets;

namespace HireMe.Domain.Features
{
    public static class DigitalAssetExtensions
    {
        public static DigitalAssetDto ToDto(this DigitalAsset digitalAsset)
        {
            return new DigitalAssetDto
            {
                DigitalAssetId = digitalAsset.DigitalAssetId,
                Name = digitalAsset.Name,
                Bytes = digitalAsset.Bytes,
                ContentType = digitalAsset.ContentType,
            };
        }
    }
}

using HireMe.Core.Models;
using HireMe.Domain.Features.Videos;

namespace HireMe.Domain.Features
{
    public static class VideoExtensions
    {
        public static VideoDto ToDto(this Video video)
        {
            return new VideoDto
            {
                VideoId = video.VideoId,
            };
        }
    }
}

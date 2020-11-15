using HireMe.Core.Models;

namespace HireMe.TestUtilities.Builders
{
    public class VideoBuilder
    {
        private Video _video;

        public VideoBuilder()
        {
            _video = new Video();
        }

        public Video Build()
        {
            return _video;
        }
    }
}

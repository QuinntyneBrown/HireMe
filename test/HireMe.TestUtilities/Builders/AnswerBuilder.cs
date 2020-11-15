using HireMe.Core.Models;

namespace HireMe.TestUtilities.Builders
{
    public class AnswerBuilder
    {
        private Answer _answer;

        public AnswerBuilder()
        {
            _answer = new Answer();
        }

        public Answer Build()
        {
            return _answer;
        }
    }
}

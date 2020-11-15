using HireMe.Core.Models;

namespace HireMe.TestUtilities.Builders
{
    public class QuestionBuilder
    {
        private Question _question;

        public QuestionBuilder()
        {
            _question = new Question();
        }

        public Question Build()
        {
            return _question;
        }
    }
}

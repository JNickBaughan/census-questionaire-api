using census_questionaire_api.Entities;

namespace census_questionaire_api.Models
{
    public class QuestionWithAnswerOptions
    {
        public int QuestionId { get; set; }

        public string QuestionText { get; set; }

        public IEnumerable<AnswerOption> Answers { get; set; }
    }
}

namespace census_questionaire_api.Entities
{
    public class AnswerOption
    {
        public int AnswerOptionId { get; set; }

        public string AnswerOptionText { get; set; }

        public bool AllowsComments { get; set; }

        public int QuestionId { get; set; }

    }

}

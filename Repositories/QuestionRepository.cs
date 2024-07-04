using census_questionaire_api.Context;
using census_questionaire_api.Entities;
using census_questionaire_api.Models;
using Dapper;

namespace census_questionaire_api.Repositories
{



    public class QuestionRepository
    {
        private readonly DapperContext _context;

        public QuestionRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<QuestionWithAnswerOptions>> GetQuestions()
        {
            try
            {
                var query = "SELECT [questionId], [questionText], [houseHoldQuestion], [order] FROM [Census].[dbo].[Questions]; " +
                    "SELECT AO.[answerOptionId],AO.[answerOptionText],AO.[allowsComments],QTAO.[questionId],QTAO.[order] " +  
                    "FROM [Census].[dbo].[AnswerOptions] AO " +
                    "LEFT JOIN [Census].[dbo].[QuestionToAnswerOptions] QTAO " +
                    "ON AO.answerOptionId = QTAO.answerOptionId";
                using (var connection = _context.CreateConnection())
                {
                    var questionsWithAnswers = await connection.QueryMultipleAsync(query);

                    var questions = await questionsWithAnswers.ReadAsync<Question>();

                    var answers = await questionsWithAnswers.ReadAsync<AnswerOption>();

                    return questions.Select(q => {
                        var answerOptions = answers.Where(a => a.QuestionId == q.QuestionId);
                        return new QuestionWithAnswerOptions()
                        {
                            QuestionId = q.QuestionId,
                            QuestionText = q.QuestionText,
                            Answers = answerOptions
                        };
                    }).ToList();
                    

                
                    
                    
                }
            }
            catch(Exception ex)
            {
                var t = ex.Message;
                throw;
            }

        }


    }
}

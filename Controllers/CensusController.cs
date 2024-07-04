using census_questionaire_api.Repositories;
using census_questionaire_api.Models;
using Microsoft.AspNetCore.Mvc;


namespace census_questionaire_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CensusController : ControllerBase
    {
        private readonly QuestionRepository _questionRepository;
        public CensusController(QuestionRepository questionRepository)
        {
            this._questionRepository = questionRepository;  
        }

        [HttpGet("questions-and-answer-options")]
        public async Task<IEnumerable<QuestionWithAnswerOptions>> Get()
        {
            return await this._questionRepository.GetQuestions();
        }
    }
}

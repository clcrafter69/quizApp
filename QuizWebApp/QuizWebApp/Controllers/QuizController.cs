using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizWebApp.Models;
using QuizWebApp.Data;
using QuizWebApp.Entities;

namespace QuizWebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Quiz")]
    public class QuizController : Controller
    {
        private readonly IQuestionRepository _questionRepo;
        private readonly IAnswerRepository _answerRepo;


        public QuizController(IQuestionRepository questionRepo, IAnswerRepository answerRepo)
        {
            _questionRepo = questionRepo;
            _answerRepo = answerRepo;
        }


        // GET: api/Quiz
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
          
        }

        // GET: api/Quiz/5

        //[HttpGet("{id}", Name = "GetAnswers")]
        //public List<Answer> GetAnswers(int id)
        //{
        //    // return "value";
        //    return _answerRepo.ListEditAnswers(id);

        //}


        [HttpGet("{id}/answers", Name = "GetAnswers")]
        public IActionResult GetQAnswers(int id)
        {
            // return "value";
            var result= _questionRepo.GetQAnswers(id);
            var questionResult = new QuestionMap()
            {
                Id = result.Id,
                Questions = result.Questions,
                LevelId = result.LevelId,
                CategoryId = result.Id

            };
            foreach (var ans in result.Answers)
            {
                questionResult.Answers.Add(
                  new AnswerMap()
                  {
                      Id = ans.Id,
                      Response = ans.Response,
                      Correct = ans.Correct
                  });                    
            }
            //return result;
            return Ok(questionResult);

        }

        //[HttpGet("{id}", Name = "GetAnswers")]
        //public List<Question> GetAnswers(int id)
        //{
        //    // return "value";
        //    return _questionRepo.ListAllQuestionsByCategory(id);

        //}

        //[HttpGet("{id}", Name = "")]
        //public List<Question> GetAnswers(int id)
        //{
        //    // return "value";
        //    return _questionRepo.ListAllQuestions();

        //}

        [HttpGet("{level}/{category}", Name = "GetQuestion")]
        public List<Question> GetQuestions(int level, int category)
        {
            // return "value";
            return _questionRepo.ListAllQuestionsByCategory(level,category);

        }

        //[HttpGet("{level}/{name}", Name = "GetQuestion")]
        //public Question GetQuestions(int level, int category)
        //{
        //    // return "value";
        //    return _questionRepo.GetQuestionById(id);

        //}

        // POST: api/Quiz
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Quiz/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
